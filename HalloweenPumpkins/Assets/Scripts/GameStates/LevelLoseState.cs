using UnityEngine;
using System.Collections;

/// <summary>
/// Level Lose Game State. When Player will loose level.
/// </summary>
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
}
