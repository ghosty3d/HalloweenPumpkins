using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelsManager : MonoBehaviour
{
	public static LevelsManager Instance;
    public LevelStorage levelStorage;
	public Level CurrentLevel;
    public Dictionary<int, int> userProgress;

	void Awake()
	{
		Instance = this;
        InitUserProgress();
        //InitLevels();
	}

    //public void InitLevels()
    //{
    //       levelStorage = ConfigManager.GetLevelStorage();
    //}

    public void InitUserProgress()
    {
        userProgress = ConfigManager.GetUserProgress();

    }

    public void SelectLevel(int id)
    {
        if (levelStorage != null)
        {
            CurrentLevel = levelStorage.levelsList[id];
        }
    }
}