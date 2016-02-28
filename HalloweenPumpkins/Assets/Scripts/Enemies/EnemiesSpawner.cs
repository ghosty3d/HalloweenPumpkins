using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class EnemiesSpawner : MonoBehaviour
{
	public static EnemiesSpawner Instance;

	public GameObject EnenmyPrefab;

	public Level currentLevel;

	public List<LevelEnemiesWave> wavesList = new List<LevelEnemiesWave>();

	public LevelEnemiesWave currentWave;
	public int currentWaveNumber;

	public int enemiesRemainingToSpawn;
	public int enemiesRemainingAlive;
	public float nextSpawnTime;
    
    public int timerBetwenWaves;
    public int timeBetwenWawesMin = 1;
    public int timeBetwenWawesMax = 3;

	[SerializeField]
	private int wavesCount;

	private bool m_Initialized = false;
	[SerializeField]
	public List<GameObject> enemiesList = new List<GameObject> ();

	private Vector3 newInitialPosition;

	void Awake()
	{
		Instance = this;
	}

	void Update()
	{
		if (m_Initialized)
		{
			if (enemiesRemainingToSpawn > 0 && Time.time > nextSpawnTime)
			{
				enemiesRemainingToSpawn--;
				nextSpawnTime = Time.time + currentWave.timeBetweenSpawns;
				System.Random prng = new System.Random ();
				float l_RandomPosX = prng.Next (-15, 15) * 0.1f;
				newInitialPosition = new Vector3 (l_RandomPosX, 6f, 0f);
				GameObject newEnemy = ObjectPoolManager.instance.ReuseObject (EnenmyPrefab, newInitialPosition, Quaternion.Euler(0f, 180f, 0f));

				if (!enemiesList.Contains (newEnemy)) {
					enemiesList.Add (newEnemy);
				}
			}
		}
	}

	public void InitializeEnemiesSpawner() {
		Debug.Log ("Init Enemy Spawner!");
		m_Initialized = true;
		currentLevel = LevelsManager.Instance.CurrentLevel;
		wavesList.AddRange(currentLevel.WavesList);
		wavesCount = currentLevel.WavesCount;
		NextWave ();

		for (int i = 0; i < EnemiesSpawner.Instance.enemiesList.Count; i++) {
			enemiesList [i].GetComponent<Enemy> ().shouldStop = false;
		}
	}

	public void OnEnemyDeath() {
		if (GameStatesManager.Instance.currentGameState == GameStatesManager.Instance.levelGameState) {
			enemiesRemainingAlive --;
			Debug.Log (string.Format("Wave: {0}, Enemies Remaining Alive: {1}", currentWaveNumber, enemiesRemainingAlive));
			if (enemiesRemainingAlive == 0) {
				NextWave();
			}
		}
	}

	void NextWave() {
		currentWaveNumber++;
		if (currentWaveNumber - 1 < wavesCount)
		{
			GameStatesManager.Instance.GameViewUI.UpdateEnemiesWaves (currentWaveNumber);
			currentWave = wavesList [currentWaveNumber - 1];
			enemiesRemainingToSpawn = currentWave.enemiesInWave;
			enemiesRemainingAlive = enemiesRemainingToSpawn;

			if (ObjectPoolManager.instance.poolSize < enemiesRemainingToSpawn)
			{
				ObjectPoolManager.instance.CreatePool (EnenmyPrefab, enemiesRemainingToSpawn);
			}
		}
		else if(currentWaveNumber - 1 == wavesList.Count && enemiesRemainingAlive == 0)
		{
			GameStatesManager.Instance.GoToWonState ();
		}
	}

	public void ResetEnemiesSpawner()
	{
		m_Initialized = false;
		currentLevel = null;
		wavesList.Clear ();
		currentWave = null;
		currentWaveNumber = 0;
		enemiesRemainingAlive = 0;
		enemiesRemainingToSpawn = 0;
		nextSpawnTime = 0;
		StopEnemiesAndHide ();
	}

	/// <summary>
	/// Stops spawn enemies and and hide them immediately.
	/// </summary>
	public void StopEnemiesAndHide()
	{
		for (int i = 0; i < enemiesList.Count; i++) {
			Debug.Log (string.Format("<color=red>Enemy {0} set false</color>", enemiesList[i].name));
			enemiesList [i].SetActive (false);
		}

		enemiesList.Clear ();

		ObjectPoolManager.instance.DeactivatePoolObjects ();
	}
}