using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Class for view of Level Selection panel.
/// </summary>
public class LevelSelectionUI : MonoBehaviour
{
	public static LevelSelectionUI Instance;

	public GameObject Grid;

	public GameObject LevelButton;

	public List<GameObject> LevelsButtons = new List<GameObject> ();

	void Awake()
	{
		Instance = this;
	}

	public void SetLevelButtons()
	{
		if (Grid.transform.childCount > 0)
		{
			LevelsButtons.Clear ();
			for (int i = 0; i < Grid.transform.childCount; i++)
			{
				Destroy(Grid.transform.GetChild (i).gameObject);
			}
		}

		if(LevelsManager.Instance.levelStorage.LevelsCount > 0)
		{
			for(int i = 0; i < LevelsManager.Instance.levelStorage.LevelsCount; i++)
			{
				Debug.Log ("Stars: " + LevelsManager.Instance.levelStorage.levelsList[i].ID);

				GameObject newLvlButton = Instantiate(LevelButton);
				newLvlButton.transform.SetParent(Grid.transform);
				newLvlButton.transform.localScale = Vector3.one;
				newLvlButton.GetComponent<LevelButton>().GetLevelData(LevelsManager.Instance.levelStorage.levelsList[i]);
				LevelsButtons.Add (newLvlButton);
			}
		}
	}
}
