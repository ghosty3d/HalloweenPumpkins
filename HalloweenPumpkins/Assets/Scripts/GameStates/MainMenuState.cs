using UnityEngine;
using System.Collections;

public class MainMenuState : IGameState
{
	public GameManager gameManager;

	public MainMenuState(GameManager manager)
	{
		gameManager = manager;
	}

	public void ToMainMenuState ()
	{
		Debug.Log("I am already in Main Menu");
		if(!gameManager.GameViewUI.MainMenuContainer.gameObject.activeInHierarchy)
		{
			gameManager.GameViewUI.ShowMainMenuContainer();
		}
	}

	public void ToLevelSelectionState ()
	{
		Debug.Log("Let's select some level to play!");
		gameManager.GameViewUI.ShowLevelSelectionContainer();
	}

	public void ToLevelStartState ()
	{

	}

	public void ToLevelWinState ()
	{
		Debug.Log("[MainMenuState] : You won this level!");
	}

	public void ToLevelLoseState ()
	{
		Debug.Log("[MainMenuState] : You lose this level!");
	}

	public void ToPauseState ()
	{
		Time.timeScale = 0f;
		gameManager.GameViewUI.ShowPauseContainer();
	}

	public void ToResumeState ()
	{
		Time.timeScale = 1f;
	}

	public void ToExitState()
	{
		Application.Quit();
	}
}
