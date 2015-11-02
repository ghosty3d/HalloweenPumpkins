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
	[SerializeField]
	private bool spawnMore = true;

	void Awake()
	{
		Instance = this;
	}

	void Start ()
	{
		SpawnEnemies(EnemiesInWave);
	}

	//Set Enemies count in Enemies Wave
	public void SetEnemiesCount(int enemiesCount)
	{
		EnemiesInWave = enemiesCount;
	}

	//Set Total Waves Count in selected Level
	public void SetWavesCount(int wavesCount)
	{
		WavesCount = wavesCount;
	}

	//Set Level Timer
	public void SetLeveTimer(int timer)
	{
		LevelTimer = timer;
		GameStatesManager.Instance.GameViewUI.SetTimer (LevelTimer);
	}

	IEnumerator StartTimer()
	{
		while(LevelTimer > 0)
		{
			LevelTimer--;
			Debug.Log ("Timer");
			GameStatesManager.Instance.GameViewUI.SetTimer(LevelTimer);
			yield return new WaitForSeconds(1f);
		}

		GameStatesManager.Instance.GoToWonState();
	}

	public void StopTimer()
	{
		StopCoroutine ("StartTimer");
		GameStatesManager.Instance.GameViewUI.SetTimer (0);
	}

	/// <summary>
	/// Starts the spawn enemies. Can be used form the outside.
	/// </summary>
	public void StartSpawnEnemies()
	{
		spawnMore = true;
		StartCoroutine(SpawnNewEnemy());
		StartCoroutine(StartTimer());
	}

	/// <summary>
	/// Coroutine spawns the new enemies wave.
	/// </summary>
	/// <returns>The new enemy.</returns>
	IEnumerator SpawnNewEnemy()
	{
		while(spawnMore)
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
				
				yield return new WaitForSeconds(LevelTimer / (WavesCount + 1));
				WavesCount--;
				GameStatesManager.Instance.GameViewUI.UpdateEnemiesWaves (WavesCount);
				SetEnemiesCount(Random.Range(4, 9));
			}
			else
			{
				GameStatesManager.Instance.GoToWonState ();
				yield return null;
			}
		}
	}

	/// <summary>
	/// Spawns the enemies. And add them to Enemies ObjectPool.
	/// </summary>
	/// <param name="count">Count of enemies in ObjectPool.</param>
	public void SpawnEnemies(int count)
	{
		if (EnenmyPrefab && count > 0)
		{
			for (int i = 0; i < count; i++)
			{
				newEnenmy = Instantiate (EnenmyPrefab);
				newEnenmy.SetActive (false);
				newEnenmy.name = EnenmyPrefab.name + "-" + (i + 1);
				EnemiesPool.Add (newEnenmy);
			}
		}
		else if (EnemiesInWave <= 0)
		{
			Debug.LogWarning ("EnemiesInWave is 0!");
		}
		else
		{
			Debug.LogWarning ("EnenmyPrefab is not set properly!");
		}
	}

	/// <summary>
	/// Stops spawn enemies, but don't hide them
	/// </summary>
	public void StopEnemies()
	{
		spawnMore = false;
		StopAllCoroutines ();
	}

	/// <summary>
	/// Stops spawn enemies and and hide them immediately.
	/// </summary>
	public void StopEnemiesAndHide()
	{
		spawnMore = false;

		StopAllCoroutines ();

		for (int i = 0; i < EnemiesPool.Count; i++) 
		{
			if (EnemiesPool [i].activeInHierarchy)
			{
				EnemiesPool [i].SetActive (false);
			}		
		}
	}
}