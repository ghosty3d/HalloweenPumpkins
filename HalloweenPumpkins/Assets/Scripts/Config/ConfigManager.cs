using UnityEngine;
using System.Collections;

public static class ConfigManager
{
    private static string _configPath;


    private static string ConfigPath
    {
        get
        {
            if (string.IsNullOrEmpty(_configPath))
            {
#if UNITY_EDITOR
                _configPath = Application.dataPath + "/Config/level.json";
#else
                _configPath = Application.persistentDataPath + "/Config/level.json";
#endif
            }

            return _configPath;
        }
    }
    public static LevelStorage GetLevelStorage()
    {

        return Serializer.Deserialize<LevelStorage>(ConfigPath);
    }

    public static void SaveLevelStorage(LevelStorage levelStorage)
    {
        Serializer.Serialize(levelStorage, ConfigPath);
#if UNITY_EDITOR
        UnityEditor.AssetDatabase.Refresh();
#endif
    }
}
	
