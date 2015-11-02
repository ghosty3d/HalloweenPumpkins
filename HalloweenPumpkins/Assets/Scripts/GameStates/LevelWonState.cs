using UnityEngine;
using System.Collections;

public class LevelWonState : IGameState
{
	public GameStatesManager gameManager;

	public LevelWonState(GameStatesManager manager)
	{
		gameManager = manager;
	}

	public void EnableState ()
	{
		if(!gameManager.GameViewUI.EndLevelContainer.activeInHierarchy)
		{
			gameManager.GameViewUI.ShowEndLevelContainer (true);
		}

		gameManager.GetNewLevelRank ();
		gameManager.enemiesSpawner.StopEnemiesAndHide ();
	}

	public void UpdateState ()
	{
		
	}

	public void DisableState ()
	{
		if(gameManager.GameViewUI.EndLevelContainer.activeInHierarchy)
		{
			gameManager.GameViewUI.HideEndLevelContainer ();
		}

		gameManager.enemiesSpawner.StopEnemiesAndHide ();
	}

//	public void ToMainMenuState ()
//	{
//		Time.timeScale = 1f;
//		gameManager.GameViewUI.HidePauseContainer();
//		gameManager.GameViewUI.HideGameUIContainer();
//		gameManager.GameViewUI.HideLevelSelectionContainer();
//		gameManager.GameViewUI.HideEndLevelContainer();
//
//		gameManager.GameViewUI.ShowMainMenuContainer();
//
//		gameManager.enemiesSpawner.StopEnemiesAndHide();
//
//		gameManager.GameViewUI.GetComponent<Canvas> ().renderMode = RenderMode.ScreenSpaceOverlay;
//	}
//
//	public void ToLevelSelectionState ()
//	{
//		throw new System.NotImplementedException ();
//	}
//
//	public void ToLevelStartState ()
//	{
//		Debug.Log("[LevelWonState] : Restarted Level");
//		gameManager.GameViewUI.HideEndLevelContainer();
//
//		gameManager.enemiesSpawner.StopEnemiesAndHide ();
//		gameManager.enemiesSpawner.SetEnemiesCount(LevelsManager.Instance.CurrentLevel.MaxEnemyCount);
//		gameManager.enemiesSpawner.SetWavesCount(LevelsManager.Instance.CurrentLevel.WavesCount);
//		gameManager.enemiesSpawner.SetLeveTimer(LevelsManager.Instance.CurrentLevel.LevelTime);
//
//		gameManager.AjustPlayerLives (gameManager.PlayerLivesMax - gameManager.PlayerLives);
//		gameManager.enemiesSpawner.StartSpawnEnemies ();
//
//		BombManger.SetStartBombsCount (gameManager.PlayerBombsCount);
//		gameManager.GameViewUI.ShowBombContainer ();
//	}
//
//	public void ToLevelWinState ()
//	{
//		Debug.Log("I am already in Level Won State!");
//	}
//
//	public void ToLevelLoseState ()
//	{
//		throw new System.NotImplementedException ();
//	}
//
//	public void ToPauseState ()
//	{
//		throw new System.NotImplementedException ();
//	}
//
//	public void ToResumeState ()
//	{
//		throw new System.NotImplementedException ();
//	}
//
//	public void ToExitState ()
//	{
//		Application.Quit ();
//	}
}