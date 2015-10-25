using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelEndUI : MonoBehaviour
{
	public static LevelEndUI Instance;
	public Text Title;

	void Awake()
	{
		Instance = this;
	}
}
