﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

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
				LevelsButtons.Add (newLvlButton);

				if (LevelsManager.Instance.LevelsList [i].isLocked)
				{
					newLvlButton.GetComponent<LevelButton> ().lockIcon.enabled = true;
					newLvlButton.GetComponent<Button> ().interactable = false;
				}
				else
				{
					newLvlButton.GetComponent<LevelButton> ().lockIcon.enabled = false;
					newLvlButton.GetComponent<Button> ().interactable = true;
				}
			}
		}
	}
}