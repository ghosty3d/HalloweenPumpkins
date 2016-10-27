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
		#if UNITY_EDITOR
		Debug.Log ("Now current state is :" + this.GetType());
		#endif

		gameManager.GameViewUI.ShowEndLevelContainer (false);

		ConfigManager.SaveUserProgress (LevelsManager.Instance.userProgress);

		if(LevelsManager.Instance.CurrentLevel.Stars != 0) {
			LevelsManager.Instance.CurrentLevel.Stars = 0;

			GameUI.Instance.HideStars ();
		}
	}

	public void UpdateState ()
	{
		
	}

	public void DisableState ()
	{
		gameManager.GameViewUI.HideEndLevelContainer ();
	}
}
