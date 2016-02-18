using UnityEngine;
using System.Collections;

/// <summary>
/// Pause Game State. Pause based on the Time.timeScale value.
/// </summary>
public class PauseState : IGameState
{
	public GameStatesManager gameManager;
	
	public PauseState(GameStatesManager manager)
	{
		gameManager = manager;
	}

	public void EnableState ()
	{
		#if UNITY_EDITOR
		Debug.Log ("Now current state is :" + this.GetType());
		#endif

		if(!gameManager.GameViewUI.PauseContainer.activeInHierarchy)
		{
			Time.timeScale = 0f;
			gameManager.GameViewUI.ShowPauseContainer ();


		}
	}

	public void UpdateState ()
	{
		
	}

	public void DisableState ()
	{
		if(gameManager.GameViewUI.PauseContainer.activeInHierarchy)
		{
			Time.timeScale = 1f;
			gameManager.GameViewUI.HidePauseContainer ();
		}
	}
}
