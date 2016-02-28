using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(AudioManager))]
public class AudioManagerEditor : Editor {

	public override void OnInspectorGUI ()
	{
		DrawDefaultInspector ();

		AudioManager audioManager = (AudioManager)target;

		audioManager.musicVolumeLevel = EditorGUILayout.Slider ("Music Volume: ", audioManager.musicVolumeLevel, -80f, 5f);
		audioManager.sfxVolumeLevel = EditorGUILayout.Slider ("SFX Volume: ", audioManager.sfxVolumeLevel, -80f, 5f);
	}
}
