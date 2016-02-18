using UnityEngine;
using System.Collections;

/// <summary>
/// Main Menu Game State.
/// </summary>
public class MainMenuState : IGameState
{
	public GameStatesManager gameManager;

	public MainMenuState(GameStatesManager manager)
	{
		gameManager = manager;
	}

	public void EnableState ()
	{
		#if UNITY_EDITOR
		Debug.Log ("Now current state is :" + this.GetType());
		#endif

		if(!gameManager.GameViewUI.MainMenuContainer.gameObject.activeInHierarchy)
		{
			gameManager.GameViewUI.ShowMainMenuContainer();

			gameManager.GameViewUI.GetComponent<Canvas> ().worldCamera = Camera.main;
			gameManager.GameViewUI.GetComponent<Canvas> ().renderMode = RenderMode.ScreenSpaceOverlay;
		}
	}

	public void UpdateState ()
	{
		
	}

	public void DisableState ()
	{
		if(gameManager.GameViewUI.MainMenuContainer.gameObject.activeInHierarchy)
		{
			gameManager.GameViewUI.HideMainMenuContainer();
		}

		if (gameManager.GameViewUI.RulesContainer.activeInHierarchy)
		{
			gameManager.GameViewUI.RulesContainer.SetActive (false);
		}
	}
}