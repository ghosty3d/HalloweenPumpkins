using UnityEngine;
using System.Collections;

public class PauseState : IGameState
{
	public GameManager gameManager;
	
	public PauseState(GameManager manager)
	{
		gameManager = manager;
	}

	public void ToMainMenuState ()
	{
		GameManager.Instance.GameViewUI.HidePauseContainer();
		GameManager.Instance.GameViewUI.HideGameUIContainer();
		GameManager.Instance.GameViewUI.HideLevelSelectionContainer();
		GameManager.Instance.GameViewUI.HideBombContainer();

		GameManager.Instance.GameViewUI.ShowMainMenuContainer();

		EnemiesSpawner.Instance.StopEnemiesAndHide();

		Time.timeScale = 1f;

		gameManager.GameViewUI.GetComponent<Canvas> ().renderMode = RenderMode.ScreenSpaceOverlay;
	}

	public void ToLevelSelectionState ()
	{
		throw new System.NotImplementedException ();
	}

	public void ToLevelStartState ()
	{
		throw new System.NotImplementedException ();
	}

	public void ToLevelWinState ()
	{
		throw new System.NotImplementedException ();
	}

	public void ToLevelLoseState ()
	{
		throw new System.NotImplementedException ();
	}

	public void ToPauseState ()
	{
		Debug.Log("I am already in Pause");
	}

	public void ToResumeState ()
	{
		GameManager.Instance.GameViewUI.HidePauseContainer();
		Time.timeScale = 1f;
	}

	public void ToExitState()
	{
		Debug.Log("Exit from app");
		Application.Quit();
	}
}
