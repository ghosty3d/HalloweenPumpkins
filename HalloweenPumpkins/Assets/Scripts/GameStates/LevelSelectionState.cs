using UnityEngine;
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

		gameManager.GameViewUI.ShowGameUIContainer();

		gameManager.enemiesSpawner.StartSpawnEnemies ();
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
