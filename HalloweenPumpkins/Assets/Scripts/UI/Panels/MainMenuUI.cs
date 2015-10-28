using UnityEngine;
using System.Collections;

public class MainMenuUI : MonoBehaviour
{
	public static MainMenuUI Instance;

	void Awake()
	{
		Instance = this;
	}
}
