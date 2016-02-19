using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WavesNumberLabel : MonoBehaviour {

	private Text textLabel;

	void OnEnable ()
	{
		if (textLabel == null)
		{
			textLabel = GetComponent<Text> ();
		}

		StartCoroutine ("FadeOutLabel");
	}
	
	IEnumerator FadeOutLabel()
	{
		textLabel.color = Color.white;

		yield return new WaitForSeconds(0.5f);

		while (textLabel.color.a > 0f) {
			textLabel.color = new Color(textLabel.color.r, textLabel.color.g, textLabel.color.b, textLabel.color.a - Time.deltaTime);
			yield return new WaitForSeconds(0.015f);
		}

		gameObject.SetActive (false);
	}
}
