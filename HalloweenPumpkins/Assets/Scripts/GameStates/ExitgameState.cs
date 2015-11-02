using UnityEngine;
using System.Collections;

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
