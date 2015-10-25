using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemiesSpawner : MonoBehaviour
{
	public static EnemiesSpawner Instance;

	public GameObject EnenmyPrefab;
	public List<GameObject> EnemiesPool = new List<GameObject>();

	//Waves
	public int WavesCount;
	public int EnemiesInWave;
	public float EnemySpawnTimer;

	public int LevelTimer = 60;

	private GameObject newEnenmy;

	void Awake()
	{
		Instance = this;
	}

	void Start ()
	{
		SpawnEnemies(EnemiesInWave);
		StartCoroutine(SpawnNewEnemy());
		StartCoroutine(StartTimer());
	}

	public void SetEnemiesCount(int enemiesCount)
	{
		EnemiesInWave = enemiesCount;
	}

	public void SetWavesCount(int wavesCount)
	{
		WavesCount = wavesCount;
	}

	public void SetLeveTimer(int timer)
	{
		LevelTimer = timer;
	}

	IEnumerator StartTimer()
	{
		while(LevelTimer > 0)
		{
			yield return new WaitForSeconds(1f);
			LevelTimer--;
			GameManager.Instance.GameViewUI.SetTimer(LevelTimer);
		}

		GameManager.Instance.currentGameState.ToLevelWinState();
	}

	IEnumerator SpawnNewEnemy()
	{
		while(true)
		{
			if(WavesCount > 0)
			{
				if(EnemiesPool.Count < EnemiesInWave)
				{
					SpawnEnemies(Mathf.Abs(EnemiesPool.Count - EnemiesInWave));
				}
				
				for(int i = 0; i < EnemiesInWave; i++)
				{
					if(!EnemiesPool[i].activeInHierarchy)
					{
						EnemiesPool[i].SetActive(true);
						EnemiesPool[i].transform.position = new Vector3(Random.Range(-2f, 2f), 5f, 0f);
						yield return new WaitForSeconds(EnemySpawnTimer);
					}
				}
				
				yield return new WaitForSeconds(EnemiesInWave * EnemySpawnTimer + 2f);
				WavesCount--;
				SetEnemiesCount(Random.Range(4, 9));
			}
			else
			{
				yield return null;
			}
		}
	}

	public void SpawnEnemies(int count)
	{
		if(EnenmyPrefab && count > 0)
		{
			for(int i = 0; i < count; i++)
			{
				newEnenmy = Instantiate(EnenmyPrefab);
				newEnenmy.SetActive(false);
				newEnenmy.name = EnenmyPrefab.name + "-" + (i + 1);
				EnemiesPool.Add(newEnenmy);
			}
		}
	}

	public void StopEnemies()
	{
		WavesCount = 0;
		EnemiesInWave = 0;

		for(int i = 0; i < EnemiesPool.Count; i++)
		{
			EnemiesPool[i].gameObject.SetActive(false);
		}
	}
}