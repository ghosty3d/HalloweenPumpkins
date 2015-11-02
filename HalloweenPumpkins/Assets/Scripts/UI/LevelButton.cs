using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class LevelButton : MonoBehaviour
{
	public int LevelID;
	public Text ButtonText;
	public Button button;
	public Image lockIcon;

	public UnityAction clickAction;

	public int StarsObtained;
	public List<GameObject> LevelStars = new List<GameObject> ();

	void Start()
	{
		ButtonText.text = LevelID.ToString();
		button = GetComponent<Button>();
		clickAction = LevelSelection;
		button.onClick.AddListener(clickAction);
	}

	public void LevelSelection()
	{
		if(LevelsManager.Instance.CurrentLevel != null)
		{
			LevelsManager.Instance.SelectLevel(LevelID);
			GameStatesManager.Instance.GoToLevelStart();
		}
	}

	public void RankLevel()
	{
		if (LevelsManager.Instance != null && LevelsManager.Instance.LevelsList.Count > 0)
		{
			//Debug.Log (LevelsManager.Instance.LevelsList[0].Stars);
			//Debug.Log(LevelID - 1);
			StarsObtained = LevelsManager.Instance.LevelsList [LevelID - 1].Stars;

			Debug.Log (StarsObtained);

			for(int i = 0; i < StarsObtained; i++)
			{
				LevelStars [i].SetActive (true);
			}
		}
		else
		{
			return;
		}
	}
}
