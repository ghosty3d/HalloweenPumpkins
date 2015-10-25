using UnityEngine;
using System.Collections;

public interface IGameState
{
	void ToMainMenuState();
	void ToLevelSelectionState();
	void ToLevelStartState();
	void ToLevelWinState();
	void ToLevelLoseState();
	void ToPauseState();
	void ToResumeState();
	void ToExitState();
}
