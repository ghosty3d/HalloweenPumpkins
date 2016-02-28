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

		gameManager.GameViewUI.ShowLevelSelectionContainer();
	}

	public void UpdateState ()
	{
		
	}

	public void DisableState ()
	{
		gameManager.GameViewUI.HideLevelSelectionContainer ();
	}
}
