using UnityEngine;
using System.Collections;

public static class ConfigManager
{
    private static string _configPath;

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

	/// <summary>
	/// Creates the initial config if it wasn't found.
	/// </summary>
	/// <param name="levelStorage">Level storage.</param>
	public static void CreateInitialConfig(LevelStorage levelStorage)
	{
		SaveLevelStorage(levelStorage);
	}

    public static LevelStorage GetLevelStorage()
    {
		LevelStorage l_LevelStorage;
		l_LevelStorage = Serializer.Deserialize<LevelStorage>(ConfigPath);

		if (l_LevelStorage == null) 
		{
			CreateInitialConfig (LevelsManager.Instance.levelStorage);
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
}