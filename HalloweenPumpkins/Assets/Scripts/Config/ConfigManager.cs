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

    public static LevelStorage GetLevelStorage()
    {
        LevelStorage l_LevelStorage;
        l_LevelStorage = Serializer.Deserialize<LevelStorage>(ConfigPath);

        if (l_LevelStorage == null)
        {
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

	public static UserProgress GetUserProgress()
	{
		UserProgress _userProgress;
		_userProgress = Serializer.Deserialize<UserProgress>(UserConfigPath);

		if (_userProgress == null)
		{
			_userProgress = new UserProgress();
		}

		return _userProgress;
	}

	public static void SaveUserProgress(UserProgress userProgress)
    {
        Serializer.Serialize(userProgress, UserConfigPath);
    }
}