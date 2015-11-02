using UnityEngine;
using System.Collections;

public interface IGameState
{
	void EnableState();
	void UpdateState ();
	void DisableState();
}
