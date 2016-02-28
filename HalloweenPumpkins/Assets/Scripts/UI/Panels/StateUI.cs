using UnityEngine;
using UnityEngine.UI;
using System.Collections;
[ExecuteInEditMode]
[RequireComponent(typeof(CanvasGroup))]
public class StateUI : MonoBehaviour {

	public CanvasGroup canvasGroup;

	void Awake() {
		canvasGroup = GetComponent<CanvasGroup> ();
	}

	public void SetActive(bool a_Flag) {
		if (a_Flag) {
			canvasGroup.alpha = 1f;
			canvasGroup.interactable = true;
			canvasGroup.blocksRaycasts = true;
		} else {
			canvasGroup.alpha = 0f;
			canvasGroup.interactable = false;
			canvasGroup.blocksRaycasts = false;
		}
	}
}
