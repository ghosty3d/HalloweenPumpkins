using UnityEngine;
using System.Collections;

public static class ConfigsPath 
{
#if UNITY_EDITOR
    public static string configPath = Application.dataPath + "/Config/level.json";
#else
     public static string configPath = Application.persistentDataPath + "/Config/level.json";
#endif
}
