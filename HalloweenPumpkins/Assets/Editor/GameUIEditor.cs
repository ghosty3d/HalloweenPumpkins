using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(GameUI))]
public class GameUIEditor : Editor {

	public override void OnInspectorGUI ()
	{
		DrawDefaultInspector ();

		GameUI gameUI = (GameUI)target;

		GUILayout.Space (16);

		GUILayout.Label ("Switch Levels States:");

		if (GUILayout.Button ("Main Menu", GUILayout.ExpandWidth(true), GUILayout.Height(32))) {
			if (gameUI.MainMenuContainer.canvasGroup.alpha == 0) {
				gameUI.ShowMainMenuContainer ();
			} else {
				gameUI.HideMainMenuContainer ();
			}
		}

		if (GUILayout.Button ("Rules", GUILayout.ExpandWidth(true), GUILayout.Height(32))) {
			if (gameUI.RulesContainer.canvasGroup.alpha == 0) {
				gameUI.ShowRulesContainer ();
			} else {
				gameUI.HideRulesContainer ();
			}
		}

		if (GUILayout.Button ("Level Selection", GUILayout.ExpandWidth(true), GUILayout.Height(32))) {
			if (gameUI.LevelSelectionContainer.canvasGroup.alpha == 0) {
				gameUI.ShowLevelSelectionContainer ();
			} else {
				gameUI.HideLevelSelectionContainer ();
			}
		}

		if (GUILayout.Button ("Game Level", GUILayout.ExpandWidth(true), GUILayout.Height(32))) {
			if (gameUI.GameUIContainer.canvasGroup.alpha == 0) {
				gameUI.ShowGameUIContainer ();
			} else {
				gameUI.HideGameUIContainer ();
			}
		}

		if (GUILayout.Button ("End Level", GUILayout.ExpandWidth(true), GUILayout.Height(32))) {
			if (gameUI.EndLevelContainer.canvasGroup.alpha == 0) {
				gameUI.ShowEndLevelContainer (true);
			} else {
				gameUI.HideEndLevelContainer ();
			}
		}

		if (GUILayout.Button ("Pause Level", GUILayout.ExpandWidth(true), GUILayout.Height(32))) {
			if (gameUI.PauseContainer.canvasGroup.alpha == 0) {
				gameUI.ShowPauseContainer ();
			} else {
				gameUI.HidePauseContainer ();
			}
		}

		if (GUILayout.Button ("Options", GUILayout.ExpandWidth(true), GUILayout.Height(32))) {
			if (gameUI.OptionsContainer.canvasGroup.alpha == 0) {
				gameUI.ShowOptionsContainer ();
			} else {
				gameUI.HideOptionsContainer ();
			}
		}
	}
}
