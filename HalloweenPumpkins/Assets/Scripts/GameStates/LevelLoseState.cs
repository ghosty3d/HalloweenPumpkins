using UnityEngine;
using System.Collections;

public class LevelLoseState : IGameState
{
	public GameManager gameManager;
	
	public LevelLoseState(GameManager manager)
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
		Debug.Log("[LevelLoseState] : Restarted Level");
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
		throw new System.NotImplementedException ();
	}

	public void ToLevelLoseState ()
	{
		Debug.Log ("I am already in LoseState");
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
		throw new System.NotImplementedException ();
	}
}
