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
        Debug.LogError("Start");
        _levelManager = LevelsManager.Instance;
		ButtonText.text = LevelID.ToString();
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

    public void RankLevel(int ID)
    {
        Debug.LogError("_levelManager" + _levelManager);
        Debug.LogError("levelStorage" + LevelsManager.Instance.levelStorage);
        Debug.LogError("levelsList" + _levelManager.levelStorage.levelsList.Count);
        int _starsCount = _levelManager.levelStorage.levelsList[ID].Stars;

        for (int i = 0; i < _starsCount; i++)
        {
            LevelStars[i].SetActive(true);
        }
    }
}
