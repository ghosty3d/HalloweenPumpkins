using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenuUI : StateUI
{
	public static MainMenuUI Instance;
	public Text copyrightLabel;

	void Awake()
	{
		Instance = this;
		base.canvasGroup = GetComponent<CanvasGroup> ();
		copyrightLabel.text = string.Format ("WTFGames © {0}", System.DateTime.Now.Year);
	}
}
