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

    private LevelsManager _levelManager;

	void OnEnable()
	{
        _levelManager = LevelsManager.Instance;
		button = GetComponent<Button>();
		clickAction = LevelSelection;
		button.onClick.AddListener(clickAction);
	}

	public void LevelSelection()
	{
		if(_levelManager.CurrentLevel != null)
		{
            _levelManager.SelectLevel(LevelID);
			GameStatesManager.Instance.GoToLevelStart();
		}
	}

    public void GetLevelData(Level _level)
    {
        //ID
        LevelID = _level.ID;
		ButtonText.text = (_level.ID + 1).ToString();

        //Locked
        if (_level.isLocked)
        {
            lockIcon.enabled = true;
            button.interactable = false;
        }
        else
        {
            lockIcon.enabled = false;
            button.interactable = true;
        }

        //Stars
		if (LevelsManager.Instance.userProgress.passedLevels.ContainsKey(LevelID))
        {
			for (int i = 0; i < LevelsManager.Instance.userProgress.passedLevels[LevelID]; i++)
            {
                LevelStars[i].SetActive(true);
            }
        }
    }
}
