using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameUI : MonoBehaviour
{
	public static GameUI Instance;

	//Containers
	public GameObject MainMenuContainer;
	public GameObject LevelSelectionContainer;
	public GameObject GameUIContainer;
	public GameObject PauseContainer;
	public GameObject EndLevelContainer;
	public GameObject BombContainer;
	public GameObject RulesContainer;

	public Text TimerText;
	public Text PlayerLivesText;
	public Text EnemiesWavesText;
	public Text BombsCountText;

	void Awake()
	{
		Instance = this;
	}

	//SetTimer
	public void SetTimer(int seconds)
	{
		seconds = Mathf.Clamp (seconds, 0, seconds);

		if(seconds > 9)
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

	//Bombs
	public void ShowBombContainer()
	{
		BombContainer.SetActive (true);
	}

	public void HideBombContainer()
	{
		BombContainer.SetActive (false);
	}

	public void UpdatePlayerLives(int value)
	{
		value = Mathf.Clamp (value, 0, value);
		PlayerLivesText.text = "Lives: " + value.ToString();
	}

	public void UpdateEnemiesWaves(int waves)
	{
		EnemiesWavesText.text = "Enemies Waves: " + waves.ToString();
	}

	public void UpdateBombsCount(int count)
	{
		BombsCountText.text = count.ToString();
	}

	//Rules

	public void ShowRulesContainer()
	{
		RulesContainer.SetActive (true);
	}

	public void HideRulesContainer()
	{
		RulesContainer.SetActive (false);
	}

	//Show Stars
	public void ActiveStars(int count)
	{
		for(int i = 0; i < count; i++)
		{
			LevelEndUI.Instance.Stars [i].SetActive (true);
		}
	}

}
