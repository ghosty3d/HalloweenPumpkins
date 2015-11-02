using UnityEngine;
using System.Collections;

public static class BombManger
{
	public static int BombsCount;

	public static void SetStartBombsCount(int bombs)
	{
		BombsCount = bombs;
		GameStatesManager.Instance.GameViewUI.UpdateBombsCount (BombsCount);
	}

	public static void AddBombs(int bombs)
	{
		BombsCount += bombs;
		GameStatesManager.Instance.GameViewUI.UpdateBombsCount (BombsCount);
	}

	public static void RemoveBombs(int bombs)
	{
		if (BombsCount > 0)
		{
			BombsCount -= bombs;
			GameStatesManager.Instance.GameViewUI.UpdateBombsCount (BombsCount);
		}
		else
		{
			GameStatesManager.Instance.GameViewUI.HideBombContainer ();
		}
	}
}