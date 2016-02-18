using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class EnemiesSpawner : MonoBehaviour
{
	public static EnemiesSpawner Instance;

	public GameObject EnenmyPrefab;
	public List<GameObject> EnemiesPool = new List<GameObject>();

	//Waves
	public int WavesCount;
	public int EnemiesInWave;
	public float EnemySpawnTimer;
    public int timeBetwenEnemySpawnMin = 750;
    public int timeBetwenEnemySpawnMax = 2500;
    public int timerBetwenWaves;
    public int timeBetwenWawesMin = 1;
    public int timeBetwenWawesMax = 3;




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

	
	/// <summary>
	/// Starts the spawn enemies. Can be used form the outside.
	/// </summary>
	public void StartSpawnEnemies()
	{
		spawnMore = true;
		StartCoroutine(SpawnNewEnemy());
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
						EnemiesPool[i].transform.position = new Vector3(UnityEngine.Random.Range(-2f, 2f), 5f, 0f);
                        System.Random prngEnemies = new System.Random();
                        EnemySpawnTimer = prngEnemies.Next(timeBetwenEnemySpawnMin, timeBetwenEnemySpawnMax)*0.5f;
                        Debug.Log(string.Format("<color=blue>EnemySpawnTimer: {0}</color>", EnemySpawnTimer));

                        yield return new WaitForSeconds(EnemySpawnTimer);
					}
				}
                

                System.Random prng = new System.Random();
                timerBetwenWaves = prng.Next(timeBetwenWawesMin, timeBetwenWawesMax);
                Debug.Log(string.Format("<color=red>timerBetwenWaves: {0}</color>", timerBetwenWaves));
                yield return new WaitForSeconds(timerBetwenWaves);
				WavesCount--;
				GameStatesManager.Instance.GameViewUI.UpdateEnemiesWaves (WavesCount);
				SetEnemiesCount(UnityEngine.Random.Range(4, 9));
			}
			else
			{
				GameStatesManager.Instance.GoToWonState ();
                break;
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
        StopEnemies();

		for (int i = 0; i < EnemiesPool.Count; i++) 
		{
			if (EnemiesPool [i].activeInHierarchy)
			{
				EnemiesPool [i].SetActive (false);
			}		
		}
	}
}