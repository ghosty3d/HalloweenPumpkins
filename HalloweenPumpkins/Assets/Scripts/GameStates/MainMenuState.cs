using UnityEngine;
using System.Collections;

public class MainMenuState : IGameState
{
	public GameStatesManager gameManager;

	public MainMenuState(GameStatesManager manager)
	{
		gameManager = manager;
	}

	public void EnableState ()
	{
		Debug.Log ("Now current state is :" + this.GetType());



		if(!gameManager.GameViewUI.MainMenuContainer.gameObject.activeInHierarchy)
		{
			gameManager.GameViewUI.ShowMainMenuContainer();

			gameManager.GameViewUI.GetComponent<Canvas> ().worldCamera = Camera.main;
			gameManager.GameViewUI.GetComponent<Canvas> ().renderMode = RenderMode.ScreenSpaceOverlay;
		}
	}

	public void UpdateState ()
	{
		//Debug.Log ("Now current state is :" + this.GetType() + " in Update");
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