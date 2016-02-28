using UnityEngine;
using UnityEngine.Audio;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class AudioManager : MonoBehaviour {

	public static AudioManager instance;
	public AudioMixer audioMixer;

	public AudioSource mainMenuAudioSource;
	public AudioSource gameLevelAudioSource;
	public AudioSource sfxAudioSource;

	public AudioClip squashSound;
	public AudioClip failSound;

	private float m_MusicVolumeLevel;
	private float m_SfxVolumeLevel;

	public float musicVolumeLevel {
		get {
			return m_MusicVolumeLevel;
		}
		set {
			m_MusicVolumeLevel = value;
			AjustAllMusicVolume (value);
		}
		
	}
	public float sfxVolumeLevel {
		get {
			return m_SfxVolumeLevel;
		}
		set {
			m_SfxVolumeLevel = value;
			AjustSFXVolume (value);
		}

	}

	void Awake() {
		instance = this;
	}

	public void PlayMainMenuMisuc() {
		Debug.Log ("PlayMainMenuMisuc");
		audioMixer.SetFloat ("mainMenuMusicVolume", 0f);
		audioMixer.SetFloat ("gameMusicVolume", -80f);

		if (mainMenuAudioSource.isPlaying) {
			mainMenuAudioSource.Stop ();
			mainMenuAudioSource.Play ();
		}
	}

	public void PlayGameMisuc() {
		Debug.Log ("PlayGameMisuc");
		audioMixer.SetFloat ("mainMenuMusicVolume", -80f);
		audioMixer.SetFloat ("gameMusicVolume", 0f);

		if (gameLevelAudioSource.isPlaying) {
			gameLevelAudioSource.Stop ();
			gameLevelAudioSource.Play ();
		}
	}

	public void AjustAllMusicVolume(float a_MusicVolume) {
		audioMixer.SetFloat ("allMusicVolume", a_MusicVolume);
	}

	public void AjustSFXVolume(float a_SFXVolume) {
		audioMixer.SetFloat ("sfxVolume", a_SFXVolume);
	}

	public void PlaySquashSound() {
		sfxAudioSource.clip = squashSound;
		sfxAudioSource.Play ();
	}

	public void PlayFailSound() {
		sfxAudioSource.Stop ();
		sfxAudioSource.clip = failSound;
		sfxAudioSource.Play ();
	}

	public void StopAllMusic() {
		
	}
}
