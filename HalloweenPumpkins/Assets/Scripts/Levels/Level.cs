using UnityEngine;
using System.Collections;

[System.Serializable]
public class Level
{
	public int ID;
	public int LevelTime;
	public int WavesCount;

	public int MinEnemyCount;
	public int MaxEnemyCount;

	public bool isLocked;

	public int Stars;

	public Level(int id, int levelTime, int wavesCount, int minEnemyCount, int maxEnemyCount, bool locked, int stars)
	{
		ID = id;
		LevelTime = levelTime;
		WavesCount = wavesCount;
		MinEnemyCount = minEnemyCount;
		MaxEnemyCount = maxEnemyCount;
		isLocked = locked;
		Stars = stars;
	}
}
