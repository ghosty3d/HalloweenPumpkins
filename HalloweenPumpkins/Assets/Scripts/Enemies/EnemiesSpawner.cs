using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class EnemiesSpawner : MonoBehaviour
{
	public static EnemiesSpawner Instance;

	public GameObject EnenmyPrefab;
	public List<GameObject> EnemiesPool = new List<GameObject>();

	//Waves
	public int WavesCount;

	//Enemies
	private int enemiesInWave;

	public float EnemySpawnTimer;
    public int timeBetwenEnemySpawnMin = 75;
    public int timeBetwenEnemySpawnMax = 250;
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
		SpawnEnemies(enemiesInWave);
	}

	//Set Enemies count in Enemies Wave
	public void SetEnemiesCount(int enemiesCount)
	{
		enemiesInWave = enemiesCount;
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
				if(EnemiesPool.Count < enemiesInWave)
				{
					SpawnEnemies(Mathf.Abs(EnemiesPool.Count - enemiesInWave));
				}
				
				for(int i = 0; i < enemiesInWave; i++)
				{
					if(!EnemiesPool[i].activeInHierarchy)
					{
						EnemiesPool[i].SetActive(true);
                        System.Random prngEnemies = new System.Random();
						EnemySpawnTimer = prngEnemies.Next(timeBetwenEnemySpawnMin, timeBetwenEnemySpawnMax) * 0.01f;
						#if UNITY_EDITOR
						Debug.Log(string.Format("<color=blue>EnemySpawnTimer: {0}</color>", EnemySpawnTimer));
						#endif

                        yield return new WaitForSeconds(EnemySpawnTimer);
					}
				}
                

                System.Random prng = new System.Random();
                timerBetwenWaves = prng.Next(timeBetwenWawesMin, timeBetwenWawesMax);
				#if UNITY_EDITOR
                Debug.Log(string.Format("<color=red>timerBetwenWaves: {0}</color>", timerBetwenWaves));
				#endif
                yield return new WaitForSeconds(timerBetwenWaves);
				WavesCount--;
				GameStatesManager.Instance.GameViewUI.UpdateEnemiesWaves (WavesCount);
				prng = new System.Random();
				SetEnemiesCount(prng.Next (LevelsManager.Instance.CurrentLevel.MinEnemyCount, LevelsManager.Instance.CurrentLevel.MaxEnemyCount));
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
		else if (enemiesInWave <= 0)
		{
			Debug.LogWarning ("EnemiesInWave is 0!");
		}
		else
		{
			Debug.LogWarning ("EnenmyPrefab is not set properly!");
		}
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