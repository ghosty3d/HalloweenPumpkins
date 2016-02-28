using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class UserProgress
{
	public Dictionary<int, int> passedLevels = new Dictionary<int, int>();

	public int pumpkinsStoped;
	public int pumpkinsPassed;
	public int pumpkinsExploded;

	private int m_ghostStoped;
	public int ghostStoped
	{
		get
		{
			return m_ghostStoped;
		}
		set
		{
			m_ghostStoped = value;
			GooglePlayManager.Instance.UnlockStopGhostsAchievement (value);
		}
	}
	public int ghostPassed;
	public int ghostExploded;

	private int m_bombsUsed;
	public int bombsUsed
	{
		get
		{
			return m_bombsUsed;
		}
		set
		{
			m_bombsUsed = value;
			GooglePlayManager.Instance.UnlockUsingBombsAchievement (value);
		}
	}

	public int livesWasted;

	public UserProgress() {
		
	}
}
