using UnityEngine;
using System.Collections;

/// <summary>
/// Exit Game State. Close application at Mobile Device.
/// </summary>
public class ExitGameState : IGameState
{
	public GameStatesManager gameManager;

	public ExitGameState(GameStatesManager manager)
	{
		gameManager = manager;
	}

	public void EnableState ()
	{
		#if UNITY_EDITOR
		Debug.Log ("Now current state is :" + this.GetType());
		#endif

		Application.Quit ();
	}

	public void UpdateState ()
	{
		
	}

	public void DisableState ()
	{
		
	}
}
