using UnityEngine;
using System.Collections;

public class LevelLoseState : IGameState
{
	public GameStatesManager gameManager;
	
	public LevelLoseState(GameStatesManager manager)
	{
		gameManager = manager;
	}

	public void EnableState ()
	{
		if(!gameManager.GameViewUI.EndLevelContainer.activeInHierarchy)
		{
			gameManager.GameViewUI.ShowEndLevelContainer (false);
		}
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
//
//		gameManager.GameViewUI.HidePauseContainer();
//		gameManager.GameViewUI.HideGameUIContainer();
//		gameManager.GameViewUI.HideLevelSelectionContainer();
//		gameManager.GameViewUI.HideEndLevelContainer();
//
//		gameManager.GameViewUI.ShowMainMenuContainer();
//		gameManager.GameViewUI.GetComponent<Canvas> ().renderMode = RenderMode.ScreenSpaceOverlay;
//
//		gameManager.enemiesSpawner.StopEnemiesAndHide();
//	}
//
//	public void ToLevelSelectionState ()
//	{
//		throw new System.NotImplementedException ();
//	}
//
//	public void ToLevelStartState ()
//	{
//		Debug.Log("[LevelLoseState] : Restarted Level");
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
//		throw new System.NotImplementedException ();
//	}
//
//	public void ToLevelLoseState ()
//	{
//		Debug.Log ("I am already in LoseState");
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
//		throw new System.NotImplementedException ();
//	}
}
