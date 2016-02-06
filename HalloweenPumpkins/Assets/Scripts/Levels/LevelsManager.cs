using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelsManager : MonoBehaviour
{
	public static LevelsManager Instance;

    public LevelStorage levelStorage;

	public Level CurrentLevel;

    public string configPath;

	void Awake()
	{
		Instance = this;
        configPath = Application.dataPath + "/Config/level.json";
        InitLevels();
	}

	public void InitLevels()
	{
        levelStorage = Serializer.Deserialize<LevelStorage>(configPath);
	}

    public void SelectLevel(int id)
    {
        if (levelStorage != null)
        {
            CurrentLevel = levelStorage.levelsList[id];
        }
    }

    public void SaveLevelResult()
    {
        Serializer.Serialize(levelStorage, configPath);
    }
}
