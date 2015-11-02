using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelsManager : MonoBehaviour
{
	public static LevelsManager Instance;

	public int LevelsCout;
	public List<Level> LevelsList = new List<Level>();

	public Level CurrentLevel;

	void Awake()
	{
		Instance = this;
		InitLevels(LevelsCout);
	}

	public void InitLevels(int count)
	{
		//Test code, here should be some kind of data from JSON or other config
		for(int i = 0; i < count; i++)
		{
			Level newLevel = new Level(i + 1, 25, 3 + i, 2 + i, 5 + i, false, 0);
			LevelsList.Add(newLevel);
		}

		//Lock last level
		LevelsList[LevelsList.Count - 1].isLocked = true;
	}

	public void SelectLevel(int id)
	{
		CurrentLevel = LevelsList[id - 1];
	}
}
