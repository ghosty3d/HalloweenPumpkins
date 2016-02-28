using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPoolManager : MonoBehaviour
{
	private static ObjectPoolManager m_Instance;

	public static ObjectPoolManager instance
	{
		get
		{
			if (m_Instance == null) {
				m_Instance = FindObjectOfType<ObjectPoolManager> ();
			}

			return m_Instance;
		}
	}

	public GameObject objectToReuse;

	public int poolSize
	{
		get
		{
			return m_ObjectPool.Count;
		}
	}

	private Queue<GameObject> m_ObjectPool = new Queue<GameObject> ();

	public void CreatePool(GameObject a_Prefab, int a_NewPoolSize)
	{
		for(int i = poolSize; i < a_NewPoolSize; i++)
		{
			GameObject newObject = Instantiate (a_Prefab);
			newObject.name = string.Format ("Enemy-{0}-{1}", (i + 1), newObject.GetInstanceID ());
			newObject.SetActive (false);
			newObject.GetComponent<Enemy> ().OnDeath += EnemiesSpawner.Instance.OnEnemyDeath;
			m_ObjectPool.Enqueue (newObject);
		}
	}

	public GameObject ReuseObject(GameObject a_Prefab, Vector3 a_Position, Quaternion a_Rotation)
	{
		objectToReuse = m_ObjectPool.Dequeue ();
		m_ObjectPool.Enqueue (objectToReuse);

		objectToReuse.SetActive (true);
		objectToReuse.transform.position = a_Position;
		objectToReuse.transform.rotation = a_Rotation;

		return objectToReuse;
	}

	public void DeactivatePoolObjects()
	{
		for (int i = 0; i < m_ObjectPool.Count; i++)
		{
			objectToReuse = m_ObjectPool.Dequeue ();
			objectToReuse.SetActive (false);
			m_ObjectPool.Enqueue (objectToReuse);
		}
	}
}
