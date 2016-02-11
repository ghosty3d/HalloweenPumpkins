using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[System.Serializable]
public class FAQRule : MonoBehaviour
{
	public Image RuleImage;
	public Text RuleDescription;

	void Awake()
	{
		if (RuleImage == null)
		{
			RuleImage = GetComponentInChildren<Image> ();
		}

		if (RuleDescription == null)
		{
			RuleDescription = GetComponentInChildren<Text> ();
		}
	}
}
