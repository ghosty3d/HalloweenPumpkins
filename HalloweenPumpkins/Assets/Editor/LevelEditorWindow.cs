using UnityEngine;
using UnityEditor;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;


public class LevelEditorWindow : EditorWindow
{
    public static string configPath = Application.dataPath + "/Config/level.json";

    public Level newLevel;

    [MenuItem("Levels/LevelsEditor")]
    static void Init()
    {
        // Get existing open window or if none, make a new one:
        LevelEditorWindow window = (LevelEditorWindow)EditorWindow.GetWindow(typeof(LevelEditorWindow));
        window.Show();

    }

    void OnGUI()
    {
        if (GUILayout.Button("Load Config", GUILayout.ExpandWidth(true), GUILayout.Height(32)))
        {
           
            Debug.Log(configPath);

          

           // Level level = new Level(2, 3, 4, 5, 6, true, 10000);
           // Serializer.Serialize(level, configPath);
            newLevel = Serializer.Deserialize<Level>(configPath);
        }

        if (newLevel != null)
        {
            newLevel.ID = EditorGUILayout.IntField(string.Format("Level ID:\t\t\t"), newLevel.ID);
            newLevel.LevelTime = EditorGUILayout.IntField(string.Format("Level Time:\t\t"), newLevel.LevelTime);
            newLevel.WavesCount = EditorGUILayout.IntField(string.Format("Level WavesCount:\t\t"), newLevel.WavesCount);
            newLevel.MinEnemyCount = EditorGUILayout.IntField(string.Format("Level MinEnemyCount:\t"), newLevel.MinEnemyCount);
            newLevel.MaxEnemyCount = EditorGUILayout.IntField(string.Format("Level MaxEnemyCount:\t"),newLevel.MaxEnemyCount);
            newLevel.isLocked = EditorGUILayout.Toggle(string.Format("Level isLocked:\t\t"), newLevel.isLocked);
            newLevel.Stars = EditorGUILayout.IntField(string.Format("Level Stars:\t\t"), newLevel.Stars);
        }

        if (GUILayout.Button("Update Config", GUILayout.ExpandWidth(true), GUILayout.Height(32)))
        {
            Serializer.Serialize(newLevel, configPath);
            AssetDatabase.Refresh();
        }
    }
}
