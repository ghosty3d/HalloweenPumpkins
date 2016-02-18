using UnityEngine;
using System.Collections;

/// <summary>
/// Level Won Game State. When Player will won level.
/// </summary>
public class LevelWonState : IGameState
{
	public GameStatesManager gameManager;

	public LevelWonState(GameStatesManager manager)
	{
		gameManager = manager;
	}

	public void EnableState ()
	{
		#if UNITY_EDITOR
		Debug.Log ("Now current state is :" + this.GetType());
		#endif

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
}