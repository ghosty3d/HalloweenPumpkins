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
		#if UNITY_EDITOR
		Debug.Log ("Now current state is :" + this.GetType());
		#endif

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
