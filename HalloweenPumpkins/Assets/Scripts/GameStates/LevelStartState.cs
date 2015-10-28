using UnityEngine;
using System.Collections;

public class LevelStartState : IGameState
{
	public GameManager gameManager;
	
	public LevelStartState(GameManager manager)
	{
		gameManager = manager;
	}

	public void ToMainMenuState ()
	{
		GameManager.Instance.GameViewUI.HidePauseContainer();
		GameManager.Instance.GameViewUI.HideGameUIContainer();
		GameManager.Instance.GameViewUI.HideLevelSelectionContainer();
		GameManager.Instance.GameViewUI.HideEndLevelContainer();

		GameManager.Instance.GameViewUI.ShowMainMenuContainer();

		EnemiesSpawner.Instance.StopEnemiesAndHide();

		Time.timeScale = 1f;
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
		Debug.Log("[LevelStartState] : You won this level!");
		gameManager.enemiesSpawner.StopEnemies();
		gameManager.GameViewUI.HideBombContainer ();
		GameUI.Instance.ShowEndLevelContainer (true);
	}

	public void ToLevelLoseState ()
	{
		Debug.Log("[LevelStartState] : You lose this level!");
		gameManager.enemiesSpawner.StopEnemies();
		gameManager.GameViewUI.HideBombContainer ();
		GameUI.Instance.ShowEndLevelContainer (false);
	}

	public void ToPauseState ()
	{
		Debug.Log("[LevelStartState] : Let's pause game!");
		Time.timeScale = 0f;
		gameManager.GameViewUI.ShowPauseContainer();
	}

	public void ToResumeState ()
	{
		throw new System.NotImplementedException ();
	}

	public void ToExitState()
	{
		Application.Quit();
	}
}
