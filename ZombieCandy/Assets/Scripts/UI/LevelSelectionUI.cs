using UnityEngine;
using System.Collections;

public class LevelSelectionUI : MonoBehaviour
{
	public static LevelSelectionUI Instance;

	public GameObject Grid;

	public GameObject LevelButton;

	void Awake()
	{
		Instance = this;
	}

	void Start()
	{
		SetLevelButtons();
	}

	public void SetLevelButtons()
	{
		if(LevelsManager.Instance.LevelsList.Count > 0)
		{
			for(int i = 0; i < LevelsManager.Instance.LevelsList.Count; i++)
			{
				GameObject newLvlButton = Instantiate(LevelButton);
				newLvlButton.transform.SetParent(Grid.transform);
				newLvlButton.transform.localScale = Vector3.one;
				newLvlButton.GetComponent<LevelButton>().LevelID = LevelsManager.Instance.LevelsList[i].ID;
			}
		}
	}
}
