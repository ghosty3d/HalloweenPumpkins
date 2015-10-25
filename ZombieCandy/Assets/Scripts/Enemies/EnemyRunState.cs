using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class EnemyRunState : IEnemyState
{
	public Enemy enemy;
	private Vector3 movement;

	public EnemyRunState(Enemy enemyInstance)
	{
		enemy = enemyInstance;
	}

	public void ToRunState ()
	{
		Debug.Log("I am already in Running State!");
	}

	public void ToDieState ()
	{
		Debug.Log("I am dying!");
	}

	public void UpdateState ()
	{
		Run();
	}

	private void Run()
	{
		if(enemy.CurrentEnemyType == Enemy.EnemiesTypes.Gingerbeardman)
		{
			movement.x = enemy.spawnedX + Mathf.Sin(Time.time);
		}
		else
		{
			movement.x = enemy.enemyTransform.position.x;
		}

		movement.y = enemy.enemyTransform.position.y - (enemy.MoveSpeed * Time.deltaTime);
		movement.z = enemy.enemyTransform.position.z;

		enemy.enemyTransform.position = movement;
	}
}
