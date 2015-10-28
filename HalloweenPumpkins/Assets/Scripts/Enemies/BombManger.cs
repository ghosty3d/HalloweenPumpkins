using UnityEngine;
using System.Collections;

public static class BombManger
{
	public static int BombsCount;

	public static void SetStartBombsCount(int bombs)
	{
		BombsCount = bombs;
		GameManager.Instance.GameViewUI.UpdateBombsCount (BombsCount);
	}

	public static void AddBombs(int bombs)
	{
		BombsCount += bombs;
		GameManager.Instance.GameViewUI.UpdateBombsCount (BombsCount);
	}

	public static void RemoveBombs(int bombs)
	{
		if (BombsCount > 0)
		{
			BombsCount -= bombs;
			GameManager.Instance.GameViewUI.UpdateBombsCount (BombsCount);
		}
		else
		{
			GameManager.Instance.GameViewUI.HideBombContainer ();
		}
	}
}