using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameUI : MonoBehaviour
{
	public static GameUI Instance;

	//Containers
	public StateUI MainMenuContainer;
	public StateUI LevelSelectionContainer;
	public StateUI GameUIContainer;
	public StateUI PauseContainer;
	public StateUI EndLevelContainer;
	public StateUI BombContainer;
	public StateUI RulesContainer;
	public StateUI OptionsContainer;

	public Text PlayerLivesText;
	public Text EnemiesWavesText;
	public Text WaveNumberLabel;
	public Text BombsCountText;

	void Awake()
	{
		Instance = this;
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
		LevelSelectionContainer.SetActive (true);
        LevelSelectionUI.Instance.SetLevelButtons();
	}
	
	public void HideLevelSelectionContainer()
	{
		LevelSelectionContainer.SetActive (false);
	}

	//Game View
	public void ShowGameUIContainer()
	{
		GameUIContainer.SetActive (true);
	}
	
	public void HideGameUIContainer()
	{
		GameUIContainer.SetActive (false);
	}

	//Pause
	public void ShowPauseContainer()
	{
		PauseContainer.SetActive (true);
	}
	
	public void HidePauseContainer()
	{
		PauseContainer.SetActive (false);
	}

	//Options
	public void ShowOptionsContainer()
	{
		OptionsContainer.SetActive (true);
	}

	public void HideOptionsContainer()
	{
		OptionsContainer.SetActive (false);
	}

	//End Level
	public void ShowEndLevelContainer(bool isWin)
	{
		EndLevelContainer.SetActive (true);

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
		EndLevelContainer.SetActive (false);
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
		WaveNumberLabel.gameObject.SetActive (true);
		WaveNumberLabel.text = string.Format ("Wave Number {0}", waves);
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

	public void ExitGame()
	{
		Application.Quit ();

		#if UNITY_EDITOR
		if(UnityEditor.EditorApplication.isPlaying)
		{
			UnityEditor.EditorApplication.isPaused = true;
		}
		#endif
	}

}
