using UnityEngine;
using UnityEditor;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;


public class LevelEditorWindow : EditorWindow
{
    public static LevelStorage levelStorage;
    public Level newLevel;
    public int selectedLevelId = 0;

    [MenuItem("Levels/LevelsEditor")]
    static void Init()
    {
        // Get existing open window or if none, make a new one:
        LevelEditorWindow window = (LevelEditorWindow)EditorWindow.GetWindow(typeof(LevelEditorWindow));
		window.autoRepaintOnSceneChange = true;
        window.Show();
    }

    void OnGUI()
    {
		if (levelStorage == null)
		{
			levelStorage = GameObject.FindObjectOfType<LevelsManager> ().levelStorage;
		}

		EditorGUILayout.Space();

		GUILayout.Label("Level Edit and Creation:", EditorStyles.boldLabel);

		if (levelStorage != null && levelStorage.LevelsCount > 0)
		{
			GUILayout.Label(string.Format("Selected Level: {0} / {1}", selectedLevelId + 1, levelStorage.LevelsCount));
		}

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

		DrawLevelInfo();

        EditorGUILayout.Space();

		if (GUILayout.Button("Create New Level", GUILayout.ExpandWidth(true), GUILayout.Height(32)))
		{
			if (levelStorage.LevelsCount == 0)
			{
				selectedLevelId = 0;
			}
			else
			{
				selectedLevelId = levelStorage.LevelsCount;
			}

			newLevel = new Level(selectedLevelId, 10, 1, 1, 3, 100, 200, false, 0);
			levelStorage.AddNewLevel (newLevel);
		}

		if (GUILayout.Button("Recalculate Eneies Waves in Level", GUILayout.ExpandWidth(true), GUILayout.Height(32)))
		{
			for (int i = 0; i < levelStorage.LevelsCount; i++) {
				levelStorage.levelsList [i].CreateEnemiesWaves (
					levelStorage.levelsList [i].WavesCount,
					levelStorage.levelsList [i].MinEnemyCount,
					levelStorage.levelsList [i].MaxEnemyCount,
					levelStorage.levelsList [i].timeBetwenEnemySpawnMin,
					levelStorage.levelsList [i].timeBetwenEnemySpawnMax
				);
			}

			GameObject.FindObjectOfType<LevelsManager> ().levelStorage = levelStorage;
		}

		if (GUILayout.Button("Delete Selected Level", GUILayout.ExpandWidth(true), GUILayout.Height(32)))
		{
			levelStorage.DeleteLevelById (selectedLevelId);

			if (selectedLevelId > 0) 
			{
				selectedLevelId--;
			}
		}

		EditorGUILayout.Space();

        if (levelStorage != null)
        {
			GUILayout.Label("Get Data From JSON Config to Level Storage:", EditorStyles.boldLabel);

			if (GUILayout.Button("Update Level Storage", GUILayout.ExpandWidth(true), GUILayout.Height(32)))
			{
				levelStorage = ConfigManager.GetLevelStorage();
				GameObject.FindObjectOfType<LevelsManager> ().levelStorage = levelStorage;
			}

			GUILayout.Label("Set Data From Level Storage to JSON Config:", EditorStyles.boldLabel);

			if (GUILayout.Button("Update JSON Config", GUILayout.ExpandWidth(true), GUILayout.Height(32)))
            {
				ConfigManager.SaveLevelStorage(levelStorage);
            }

			GUILayout.Label(string.Format("JSON Config stored in:\n{0}\n", ConfigManager.ConfigPath));
        }

		EditorGUILayout.Space();

		if (GUILayout.Button("Open Config Folder", GUILayout.ExpandWidth(true), GUILayout.Height(32)))
		{
			EditorUtility.RevealInFinder (Path.GetDirectoryName(ConfigManager.ConfigPath));
		}

    }

    void DrawLevelInfo()
    {
        if (newLevel != null)
        {
            newLevel.ID = EditorGUILayout.IntField(string.Format("Level ID:\t\t\t"), newLevel.ID);
            newLevel.WavesCount = EditorGUILayout.IntField(string.Format("Level WavesCount:\t\t"), newLevel.WavesCount);
            newLevel.MinEnemyCount = EditorGUILayout.IntField(string.Format("Level MinEnemyCount:\t"), newLevel.MinEnemyCount);
            newLevel.MaxEnemyCount = EditorGUILayout.IntField(string.Format("Level MaxEnemyCount:\t"), newLevel.MaxEnemyCount);
			newLevel.timeBetwenEnemySpawnMin = EditorGUILayout.IntField(string.Format("Time Betwen Enemy Spawn Min:\t"), newLevel.timeBetwenEnemySpawnMin);
			newLevel.timeBetwenEnemySpawnMax = EditorGUILayout.IntField(string.Format("Time Betwen Enemy Spawn Max:\t"), newLevel.timeBetwenEnemySpawnMax);
            newLevel.isLocked = EditorGUILayout.Toggle(string.Format("Level isLocked:\t\t"), newLevel.isLocked);
            newLevel.Stars = EditorGUILayout.IntField(string.Format("Level Stars:\t\t"), newLevel.Stars);
        }

    }
}
