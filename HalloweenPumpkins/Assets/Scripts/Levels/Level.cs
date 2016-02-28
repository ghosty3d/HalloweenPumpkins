using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
[ExecuteInEditMode]
public class Level
{
	public int ID;
	public int WavesCount;

	public int MinEnemyCount;
	public int MaxEnemyCount;

	public int timeBetwenEnemySpawnMin;
	public int timeBetwenEnemySpawnMax;

	public bool isLocked;

	public int Stars;

	public List<LevelEnemiesWave> WavesList;

	public Level(int id, int levelTime, int wavesCount, int minEnemyCount, int maxEnemyCount, int a_timeBetwenEnemySpawnMin, int a_timeBetwenEnemySpawnMax, bool locked, int stars)
	{
		ID = id;
		WavesCount = wavesCount;
		MinEnemyCount = minEnemyCount;
		MaxEnemyCount = maxEnemyCount;
		timeBetwenEnemySpawnMin = a_timeBetwenEnemySpawnMin;
		timeBetwenEnemySpawnMax = a_timeBetwenEnemySpawnMax;
		isLocked = locked;
		Stars = stars;
		CreateEnemiesWaves (wavesCount, minEnemyCount, maxEnemyCount, a_timeBetwenEnemySpawnMin, a_timeBetwenEnemySpawnMax);
	}

	public void CreateEnemiesWaves(int a_WavesCount, int a_MinEnemyCount, int a_MaxEnemyCount, int timeBetwenEnemySpawnMin, int timeBetwenEnemySpawnMax)
	{
		if (WavesList == null) {
			WavesList = new List<LevelEnemiesWave> ();
		} else {
			WavesList.Clear ();
		}

		System.Random prng = new System.Random ();

		for(int i = 0; i < a_WavesCount; i++)
		{			
			int l_EnemiesInWave = prng.Next (a_MinEnemyCount, a_MaxEnemyCount);
			float l_TimeBetweenSpawns = prng.Next (timeBetwenEnemySpawnMin, timeBetwenEnemySpawnMax) * 0.1f;
			LevelEnemiesWave newEnemyWave = new LevelEnemiesWave (l_EnemiesInWave, l_TimeBetweenSpawns);
			WavesList.Add (newEnemyWave);
		}
	}
}
