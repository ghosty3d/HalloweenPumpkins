using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// Level Selection Game State.
/// </summary>
public class LevelSelectionState : IGameState
{
	public GameStatesManager gameManager;
	
	public LevelSelectionState(GameStatesManager manager)
	{
		gameManager = manager;
	}

	public void EnableState ()
	{       
		Debug.Log ("Now current state is :" + this.GetType());

		if (!gameManager.GameViewUI.LevelSelectionContainer.activeInHierarchy)
        {
            gameManager.GameViewUI.ShowLevelSelectionContainer();
        }
	}

	public void UpdateState ()
	{
		
	}

	public void DisableState ()
	{
		if (gameManager.GameViewUI.LevelSelectionContainer.activeInHierarchy)
		{
			gameManager.GameViewUI.HideLevelSelectionContainer ();
		}
	}
}
