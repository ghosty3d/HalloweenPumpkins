using UnityEngine;
using System.Collections;

[System.Serializable]
public class LevelEnemiesWave
{
	public int enemiesInWave;
	public float timeBetweenSpawns;

	public LevelEnemiesWave(int a_EnemiesInWave, float a_TimeBetweenSpawns) {
		enemiesInWave = a_EnemiesInWave;
		timeBetweenSpawns = a_TimeBetweenSpawns;
	}
}
