using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelsManager : MonoBehaviour
{
	public static LevelsManager Instance;

    public LevelStorage levelStorage;

	public Level CurrentLevel;



	void Awake()
	{
        Debug.LogError("!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
		Instance = this;
        
        InitLevels();
	}

	public void InitLevels()
	{
        levelStorage = ConfigManager.GetLevelStorage();
	}

    public void SelectLevel(int id)
    {
        if (levelStorage != null)
        {
            CurrentLevel = levelStorage.levelsList[id];
        }
    }
}
