using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class ConfigManager
{
    private static string _configPath;
    private static string _userConfigPath;

	public static string ConfigPath
    {
        get
        {
            if (string.IsNullOrEmpty(_configPath))
            {
				_configPath = Application.persistentDataPath + "/Config/level.json";
            }

            return _configPath;
        }
    }

    public static string UserConfigPath
    {
        get
        {
            if (string.IsNullOrEmpty(_userConfigPath))
            {
                _userConfigPath = Application.persistentDataPath + "/Config/userConfig.json";
            }

            return _userConfigPath;
        }
    }

    /// <summary>
    /// Creates the initial config if it wasn't found.
    /// </summary>
    /// <param name="levelStorage">Level storage.</param>
    public static void CreateInitialConfig(LevelStorage levelStorage)
	{
		//SaveLevelStorage(levelStorage);
	}

    public static LevelStorage GetLevelStorage()
    {
        LevelStorage l_LevelStorage;
        l_LevelStorage = Serializer.Deserialize<LevelStorage>(ConfigPath);

        if (l_LevelStorage == null)
        {
            CreateInitialConfig(LevelsManager.Instance.levelStorage);
            l_LevelStorage = Serializer.Deserialize<LevelStorage>(ConfigPath);
        }

        return l_LevelStorage;
    }

    public static void SaveLevelStorage(LevelStorage levelStorage)
    {
        Serializer.Serialize(levelStorage, ConfigPath);
#if UNITY_EDITOR
        UnityEditor.AssetDatabase.Refresh();
#endif
    }

    public static Dictionary<int,int> GetUserProgress()
    {
        Dictionary<int, int> _userProgress;
        _userProgress = Serializer.Deserialize<Dictionary<int,int>>(UserConfigPath);

        if (_userProgress == null)
        {
            _userProgress = new Dictionary<int, int>();
        }

        return _userProgress;
    }

    public static void SaveUserProgress(Dictionary<int,int> userProgress)
    {
        Serializer.Serialize(userProgress, UserConfigPath);
    }
}