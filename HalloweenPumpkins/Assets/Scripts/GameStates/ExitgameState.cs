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
		Application.Quit ();
	}

	public void UpdateState ()
	{
		
	}

	public void DisableState ()
	{
		
	}
}
