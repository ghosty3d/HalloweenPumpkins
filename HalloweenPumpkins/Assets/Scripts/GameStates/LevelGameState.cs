using UnityEngine;
using System.Collections;

/// <summary>
/// Level Game State. Actualy GamePlay State at the loaded level.
/// </summary>
public class LevelGameState : IGameState
{
	public GameStatesManager gameManager;
	
	public LevelGameState(GameStatesManager manager)
	{
		gameManager = manager;
	}

	public void EnableState ()
	{
		#if UNITY_EDITOR
		Debug.Log ("Now current state is :" + this.GetType());
		#endif

		gameManager.GameViewUI.ShowBombContainer ();
		gameManager.GameViewUI.ShowGameUIContainer ();

		BombManger.SetStartBombsCount (gameManager.PlayerBombsCount);

		gameManager.GameViewUI.GetComponent<Canvas> ().worldCamera = Camera.main;
		gameManager.GameViewUI.GetComponent<Canvas> ().renderMode = RenderMode.ScreenSpaceCamera;

		gameManager.AjustPlayerLives (gameManager.PlayerLivesMax - gameManager.PlayerLives);
		gameManager.enemiesSpawner.ResetEnemiesSpawner ();
		gameManager.enemiesSpawner.InitializeEnemiesSpawner ();

		//Audio
		AudioManager.instance.PlayGameMisuc();
	}

	public void UpdateState ()
	{
		
	}

	public void DisableState ()
	{
		gameManager.GameViewUI.HideBombContainer ();
		gameManager.GameViewUI.HideGameUIContainer ();
		gameManager.GameViewUI.HidePauseContainer ();
		gameManager.enemiesSpawner.ResetEnemiesSpawner ();
	}
}
