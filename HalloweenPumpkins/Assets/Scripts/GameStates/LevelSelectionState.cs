using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelSelectionState : IGameState
{
	public GameManager gameManager;
	
	public LevelSelectionState(GameManager manager)
	{
		gameManager = manager;
	}

	public void ToMainMenuState ()
	{

	}

	public void ToLevelSelectionState ()
	{
		throw new System.NotImplementedException ();
	}

	public void ToLevelStartState ()
	{
		Debug.Log("[LevelSelectionState] : Started Level");
		gameManager.GameViewUI.HideMainMenuContainer();
		gameManager.GameViewUI.HideLevelSelectionContainer();

		gameManager.enemiesSpawner.SetEnemiesCount(LevelsManager.Instance.CurrentLevel.MaxEnemyCount);
		gameManager.enemiesSpawner.SetWavesCount(LevelsManager.Instance.CurrentLevel.WavesCount);
		gameManager.enemiesSpawner.SetLeveTimer(LevelsManager.Instance.CurrentLevel.LevelTime);

		gameManager.AjustPlayerLives (gameManager.PlayerLivesMax - gameManager.PlayerLives);

		gameManager.GameViewUI.ShowGameUIContainer();
		gameManager.GameViewUI.ShowBombContainer();
		gameManager.GameViewUI.UpdateEnemiesWaves (LevelsManager.Instance.CurrentLevel.WavesCount);

		gameManager.enemiesSpawner.StartSpawnEnemies ();

		gameManager.GameViewUI.GetComponent<Canvas> ().renderMode = RenderMode.ScreenSpaceCamera;
		gameManager.GameViewUI.GetComponent<Canvas> ().worldCamera = Camera.main;

		BombManger.SetStartBombsCount (gameManager.PlayerBombsCount);
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
		throw new System.NotImplementedException ();
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
