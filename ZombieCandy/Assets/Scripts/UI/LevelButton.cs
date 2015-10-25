using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Collections;

public class LevelButton : MonoBehaviour
{
	public int LevelID;
	public Text ButtonText;
	public Button button;

	public UnityAction clickAction;

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
			GameManager.Instance.GoToLevelStart();
		}
	}
}
