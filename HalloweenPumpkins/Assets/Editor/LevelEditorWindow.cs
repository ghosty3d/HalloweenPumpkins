using UnityEngine;
using UnityEditor;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;


public class LevelEditorWindow : EditorWindow
{
    public static string configPath = Application.dataPath + "/Config/level.json";

    public LevelStorage levelStorage;
    public Level newLevel;
    public int selectedLevelId = 0;

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
            levelStorage = Serializer.Deserialize<LevelStorage>(configPath);
            Debug.Log(levelStorage.levelsList.Count);
        }

        EditorGUILayout.Space();

        if (GUILayout.Button("Create New Level", GUILayout.ExpandWidth(true), GUILayout.Height(32)))
        {
            levelStorage = Serializer.Deserialize<LevelStorage>(configPath);
        }

        GUILayout.Label("Levels List: ");

        if (levelStorage == null)
        {
            levelStorage = new LevelStorage();
            levelStorage.levelsList = new List<Level>();
        }
        else
        {
            GUILayout.BeginHorizontal();

            if (GUILayout.Button("Prev", GUILayout.Height(32)))
            {
                if (selectedLevelId > 0)
                {
                    if (levelStorage.levelsList.Count > 1)
                    {
                        selectedLevelId--;
                        newLevel = levelStorage.levelsList[selectedLevelId];
                    }
                }
            }
            if (GUILayout.Button("Next", GUILayout.Height(32)))
            {
                if (selectedLevelId < levelStorage.levelsList.Count - 1)
                {
                    if (levelStorage.levelsList.Count > 1)
                    {
                        selectedLevelId++;
                        newLevel = levelStorage.levelsList[selectedLevelId];
                    }
                }

            }

            GUILayout.EndHorizontal();
        }

        DrawLevelInfo();

        EditorGUILayout.Space();

        if (levelStorage != null)
        {
            if (GUILayout.Button("Update Config", GUILayout.ExpandWidth(true), GUILayout.Height(32)))
            {
                Serializer.Serialize(levelStorage, configPath);
                AssetDatabase.Refresh();
            }
        }

    }

    void DrawLevelInfo()
    {
        if (newLevel != null)
        {
            newLevel.ID = EditorGUILayout.IntField(string.Format("Level ID:\t\t\t"), newLevel.ID);
            newLevel.LevelTime = EditorGUILayout.IntField(string.Format("Level Time:\t\t"), newLevel.LevelTime);
            newLevel.WavesCount = EditorGUILayout.IntField(string.Format("Level WavesCount:\t\t"), newLevel.WavesCount);
            newLevel.MinEnemyCount = EditorGUILayout.IntField(string.Format("Level MinEnemyCount:\t"), newLevel.MinEnemyCount);
            newLevel.MaxEnemyCount = EditorGUILayout.IntField(string.Format("Level MaxEnemyCount:\t"), newLevel.MaxEnemyCount);
            newLevel.isLocked = EditorGUILayout.Toggle(string.Format("Level isLocked:\t\t"), newLevel.isLocked);
            newLevel.Stars = EditorGUILayout.IntField(string.Format("Level Stars:\t\t"), newLevel.Stars);
        }

    }
}
