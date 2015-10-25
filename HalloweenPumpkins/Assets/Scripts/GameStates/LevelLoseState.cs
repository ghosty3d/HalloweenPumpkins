using UnityEngine;
using System.Collections;

public class LevelLoseState : IGameState
{
	public GameManager gameManager;
	
	public LevelLoseState(GameManager manager)
	{
		gameManager = manager;
	}

	public void ToMainMenuState ()
	{
		throw new System.NotImplementedException ();
	}

	public void ToLevelSelectionState ()
	{
		throw new System.NotImplementedException ();
	}

	public void ToLevelStartState ()
	{
		throw new System.NotImplementedException ();
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

	public void ToExitState ()
	{
		throw new System.NotImplementedException ();
	}
}
