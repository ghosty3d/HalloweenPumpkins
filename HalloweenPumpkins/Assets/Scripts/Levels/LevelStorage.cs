using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]

public class LevelStorage
{
    public List<Level> levelsList;

    public int LevelsCount
    {
        get
        {
            if (levelsList != null)
                return levelsList.Count;
            else
                return 0;
        }
    }

    public LevelStorage()
    {

    }

    public void AddNewLevel(Level level)
    {
        if (levelsList == null)
        {
            levelsList = new List<Level>();
        }
        if (levelsList.Find(q => q.ID == level.ID) != null)
        {
            Debug.LogError("Level List already has level with this ID: " + level.ID);
            return;
        }

        levelsList.Add(level);
    }

    public void DeleteLevelById(int levelId)
    {
        if (levelsList == null)
        {
            Debug.LogError("levels list is NULL");
            return;
        }
        Level levelToDelete = levelsList.Find(q => q.ID == levelId);

        if (levelToDelete != null)
        {
            levelsList.Remove(levelToDelete);
        }
    }
}
