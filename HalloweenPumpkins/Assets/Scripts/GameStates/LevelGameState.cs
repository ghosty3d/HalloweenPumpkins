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
		Debug.Log ("Now current state is :" + this.GetType());

		if (!gameManager.GameViewUI.BombContainer.activeInHierarchy)
		{
			gameManager.GameViewUI.ShowBombContainer ();
		}

		if (!gameManager.GameViewUI.GameUIContainer.activeInHierarchy)
		{
			gameManager.GameViewUI.ShowGameUIContainer ();
		}

		BombManger.SetStartBombsCount (gameManager.PlayerBombsCount);

		gameManager.GameViewUI.GetComponent<Canvas> ().worldCamera = Camera.main;
		gameManager.GameViewUI.GetComponent<Canvas> ().renderMode = RenderMode.ScreenSpaceCamera;

		gameManager.GameViewUI.UpdateEnemiesWaves (gameManager.levelManager.CurrentLevel.WavesCount);

		gameManager.AjustPlayerLives (gameManager.PlayerLivesMax - gameManager.PlayerLives);

		gameManager.enemiesSpawner.SetEnemiesCount(gameManager.levelManager.CurrentLevel.MaxEnemyCount);
		gameManager.enemiesSpawner.SetWavesCount(gameManager.levelManager.CurrentLevel.WavesCount);
		gameManager.enemiesSpawner.SetLeveTimer(gameManager.levelManager.CurrentLevel.LevelTime);
		gameManager.enemiesSpawner.StartSpawnEnemies ();
	}

	public void UpdateState ()
	{
		
	}

	public void DisableState ()
	{
		if (gameManager.GameViewUI.BombContainer.activeInHierarchy)
		{
			gameManager.GameViewUI.HideBombContainer ();
		}

		if (gameManager.GameViewUI.GameUIContainer.activeInHierarchy)
		{
			gameManager.GameViewUI.HideGameUIContainer ();
		}

		gameManager.enemiesSpawner.StopEnemiesAndHide ();
	}
}
