using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SFXVolumeSlider : MonoBehaviour {

	private Slider m_Slider;

	void Awake() {
		m_Slider = GetComponent<Slider> ();
		m_Slider.onValueChanged.AddListener (OnSliderValueChange);
	}

	private void UpdateSlider() {
		m_Slider.value = AudioManager.instance.sfxVolumeLevel;
	}

	private void OnSliderValueChange(float a_Value) {
		AudioManager.instance.sfxVolumeLevel = a_Value;
	}

}
