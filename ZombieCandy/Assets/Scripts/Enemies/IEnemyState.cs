using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public interface IEnemyState
{
	void ToRunState();
	void ToDieState();
	void UpdateState();
}
