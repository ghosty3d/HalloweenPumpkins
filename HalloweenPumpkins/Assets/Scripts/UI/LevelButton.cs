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
		if (LevelsManager.Instance != null && LevelsManager.Instance.levelStorage.LevelsCount > 0)
		{
			//Debug.Log (LevelsManager.Instance.LevelsList[0].Stars);
			//Debug.Log(LevelID - 1);


			for(int i = 0; i < LevelsManager.Instance.CurrentLevel.Stars; i++)
			{
				LevelStars [i].SetActive (true);
			}
		}
	}
}
