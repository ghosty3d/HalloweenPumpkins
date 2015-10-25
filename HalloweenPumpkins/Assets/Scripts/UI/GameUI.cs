using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameUI : MonoBehaviour
{
	public static GameUI Instance;

	public GameObject MainMenuContainer;
	public GameObject LevelSelectionContainer;
	public GameObject GameUIContainer;
	public GameObject PauseContainer;
	public GameObject EndLevelContainer;

	public Text TimerText;
	public Text PlayerLivesText;

	void Awake()
	{
		Instance = this;
	}

	//SetTimer
	public void SetTimer(int seconds)
	{
		if(seconds > 10)
		{
			TimerText.text = "0:" + seconds.ToString();
		}
		else
		{
			TimerText.text = "0:0" + seconds.ToString();
		}
	}

	//Main Menu
	public void ShowMainMenuContainer()
	{
		MainMenuContainer.SetActive(true);
	}

	public void HideMainMenuContainer()
	{
		MainMenuContainer.SetActive(false);
	}

	//Level Selection
	public void ShowLevelSelectionContainer()
	{
		LevelSelectionContainer.SetActive(true);
	}
	
	public void HideLevelSelectionContainer()
	{
		LevelSelectionContainer.SetActive(false);
	}

	//Game View
	public void ShowGameUIContainer()
	{
		GameUIContainer.SetActive(true);
	}
	
	public void HideGameUIContainer()
	{
		GameUIContainer.SetActive(false);
	}

	//Pause
	public void ShowPauseContainer()
	{
		PauseContainer.SetActive(true);
	}
	
	public void HidePauseContainer()
	{
		PauseContainer.SetActive(false);
	}

	//End Level
	public void ShowEndLevelContainer(bool isWin)
	{
		EndLevelContainer.SetActive(true);
		if (isWin)
		{
			LevelEndUI.Instance.Title.text = "You won this level!";	
		}
		else 
		{
			LevelEndUI.Instance.Title.text = "You lose this level!";	
		}
	}

	public void HideEndLevelContainer()
	{
		EndLevelContainer.SetActive(false);
	}

	public void UpdatePlayerLives(int value)
	{
		value = Mathf.Clamp (value, 0, value);
		PlayerLivesText.text = "Lives: " + value.ToString();
	}
}
