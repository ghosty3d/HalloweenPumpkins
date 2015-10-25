using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelsManager : MonoBehaviour
{
	public static LevelsManager Instance;

	public List<Level> LevelsList = new List<Level>();

	public Level CurrentLevel;

	void Awake()
	{
		Instance = this;
		InitLevels(5);
	}

	public void InitLevels(int count)
	{
		for(int i = 0; i < count; i++)
		{
			Level newLevel = new Level(i + 1, 10, 3 + i, 2 + i, 5 + i);
			LevelsList.Add(newLevel);
		}
	}

	public void SelectLevel(int id)
	{
		CurrentLevel = LevelsList[id - 1];
	}
}
