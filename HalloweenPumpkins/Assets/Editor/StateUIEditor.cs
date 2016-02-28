using UnityEngine;
using UnityEditor;
using System.Collections;
[CustomEditor(typeof(StateUI))]
public class StateUIEditor : Editor {

	public override void OnInspectorGUI ()
	{
		DrawDefaultInspector ();

		StateUI stateUI = (StateUI)target;

		if (GUILayout.Button ("Show this panel", GUILayout.ExpandWidth (true), GUILayout.Height (32))) {
			stateUI.canvasGroup.alpha = 1f;
		}

		if (GUILayout.Button ("Hide this panel", GUILayout.ExpandWidth (true), GUILayout.Height (32))) {
			stateUI.canvasGroup.alpha = 0f;
		}
	}
}
