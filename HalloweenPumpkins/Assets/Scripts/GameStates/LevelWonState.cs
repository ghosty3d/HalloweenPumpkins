using UnityEngine;
using System.Collections;

public class LevelWonState : IGameState
{
	public GameManager gameManager;

	public LevelWonState(GameManager manager)
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

		gameManager.GameViewUI.GetComponent<Canvas> ().renderMode = RenderMode.ScreenSpaceOverlay;
	}

	public void ToLevelSelectionState ()
	{
		throw new System.NotImplementedException ();
	}

	public void ToLevelStartState ()
	{
		Debug.Log("[LevelWonState] : Restarted Level");
		gameManager.GameViewUI.HideEndLevelContainer();

		gameManager.enemiesSpawner.StopEnemiesAndHide ();
		gameManager.enemiesSpawner.SetEnemiesCount(LevelsManager.Instance.CurrentLevel.MaxEnemyCount);
		gameManager.enemiesSpawner.SetWavesCount(LevelsManager.Instance.CurrentLevel.WavesCount);
		gameManager.enemiesSpawner.SetLeveTimer(LevelsManager.Instance.CurrentLevel.LevelTime);

		gameManager.AjustPlayerLives (gameManager.PlayerLivesMax - gameManager.PlayerLives);
		gameManager.enemiesSpawner.StartSpawnEnemies ();

		BombManger.SetStartBombsCount (gameManager.PlayerBombsCount);
		gameManager.GameViewUI.ShowBombContainer ();
	}

	public void ToLevelWinState ()
	{
		Debug.Log("I am already in Level Won State!");
	}

	public void ToLevelLoseState ()
	{
		throw new System.NotImplementedException ();
	}

	public void ToPauseState ()
	{
		throw new System.NotImplementedException ();
	}

	public void ToResumeState ()
	{
		throw new System.NotImplementedException ();
	}

	public void ToExitState ()
	{
		Application.Quit ();
	}
}
