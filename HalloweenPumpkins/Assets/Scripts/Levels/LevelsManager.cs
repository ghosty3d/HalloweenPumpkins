using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelsManager : MonoBehaviour
{
	public static LevelsManager Instance;
    public LevelStorage levelStorage;
	public Level CurrentLevel;
	public UserProgress userProgress;

	void Awake()
	{
		Instance = this;
        InitUserProgress();
	}

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