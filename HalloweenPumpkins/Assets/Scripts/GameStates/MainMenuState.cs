using UnityEngine;
using System.Collections;

public class MainMenuState : IGameState
{
	public GameStatesManager gameManager;

	public MainMenuState(GameStatesManager manager)
	{
		gameManager = manager;
	}

	public void EnableState ()
	{
		Debug.Log ("Now current state is :" + this.GetType());

		if(!gameManager.GameViewUI.MainMenuContainer.gameObject.activeInHierarchy)
		{
			gameManager.GameViewUI.ShowMainMenuContainer();

			gameManager.GameViewUI.GetComponent<Canvas> ().worldCamera = Camera.main;
			gameManager.GameViewUI.GetComponent<Canvas> ().renderMode = RenderMode.ScreenSpaceOverlay;
		}
	}

	public void UpdateState ()
	{
		Debug.Log ("Now current state is :" + this.GetType() + " in Update");
	}

	public void DisableState ()
	{
		if(gameManager.GameViewUI.MainMenuContainer.gameObject.activeInHierarchy)
		{
			gameManager.GameViewUI.HideMainMenuContainer();
		}

		if (gameManager.GameViewUI.RulesContainer.activeInHierarchy)
		{
			gameManager.GameViewUI.RulesContainer.SetActive (false);
		}
	}

//	public void ToMainMenuState ()
//	{
//		Debug.Log("I am already in Main Menu");
//
//
//		if(gameManager.GameViewUI.GameUIContainer.activeInHierarchy)
//		{
//			gameManager.GameViewUI.HideGameUIContainer ();
//		}
//
//		if(gameManager.GameViewUI.BombContainer.activeInHierarchy)
//		{
//			gameManager.GameViewUI.HideBombContainer ();
//		}
//	}
//
//	public void ToLevelSelectionState ()
//	{
//		Debug.Log("Let's select some level to play!");
//		gameManager.GameViewUI.ShowLevelSelectionContainer();
//
//	}
//
//	public void ToLevelStartState ()
//	{
//
//	}
//
//	public void ToLevelWinState ()
//	{
//		Debug.Log("[MainMenuState] : You won this level!");
//	}
//
//	public void ToLevelLoseState ()
//	{
//		Debug.Log("[MainMenuState] : You lose this level!");
//	}
//
//	public void ToPauseState ()
//	{
//		Time.timeScale = 0f;
//		gameManager.GameViewUI.ShowPauseContainer();
//	}
//
//	public void ToResumeState ()
//	{
//		Time.timeScale = 1f;
//	}
//
//	public void ToExitState()
//	{
//		Application.Quit();
//	}
}
