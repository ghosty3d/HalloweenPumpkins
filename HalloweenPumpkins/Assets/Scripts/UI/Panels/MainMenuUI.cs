using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenuUI : MonoBehaviour
{
	public static MainMenuUI Instance;
	public Text copyrightLabel;

	void Awake()
	{
		Instance = this;
		copyrightLabel.text = string.Format ("WTFGames © {0}", System.DateTime.Now.Year);
	}
}
