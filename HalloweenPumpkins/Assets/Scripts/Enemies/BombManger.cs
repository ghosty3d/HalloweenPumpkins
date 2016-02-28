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

			//if it was used bomb set it in User's Progress
			LevelsManager.Instance.userProgress.bombsUsed++;
			ConfigManager.SaveUserProgress (LevelsManager.Instance.userProgress);
		}
		else
		{
			GameStatesManager.Instance.GameViewUI.HideBombContainer ();
		}
	}
}