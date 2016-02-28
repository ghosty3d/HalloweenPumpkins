using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class LevelEndUI : StateUI
{
	public static LevelEndUI Instance;
	public Text Title;

	public List<GameObject> Stars = new List<GameObject> ();

	void Awake()
	{
		Instance = this;
		base.canvasGroup = GetComponent<CanvasGroup> ();
	}
}
