using UnityEngine;
using System.Collections;

/// <summary>
/// Interface for basic Game States Machine.
/// </summary>
public interface IGameState
{
	void EnableState();
	void UpdateState ();
	void DisableState();
}
