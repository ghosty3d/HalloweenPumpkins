using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class Enemy : MonoBehaviour
{
	public Transform enemyTransform;

	public float SlideSpeed;
	public float MoveSpeed;

	public IEnemyState currentSate;

	public IEnemyState runSate;
	public IEnemyState dieSate;

	public enum EnemiesTypes
	{
		Mafin,
		IceCream,
		Gingerbeardman
	}

	public EnemiesTypes CurrentEnemyType;

	public float UntouchableChanse;

	public Color EnemyColor;
	public List<Texture2D> EnemiesTexturesList = new List<Texture2D>();

	private MeshRenderer enemyMeshRenderer;
	public float spawnedX;

	private bool clicked = false;

	void Awake()
	{
		enemyTransform = transform;
		enemyMeshRenderer = GetComponent<MeshRenderer>();

		runSate = new EnemyRunState(this);
	}

	void OnEnable()
	{
		currentSate = runSate;

		SlideSpeed = Random.Range(0.25f, 2f);
		//MoveSpeed = Random.Range(0.75f, 1f);

		spawnedX = enemyTransform.position.x;

		ChangeEnemyType();
	}

	void Start ()
	{
		currentSate = runSate;
	}

	void Update ()
	{
		currentSate.UpdateState();
	}

//	public void OnPointerClick (PointerEventData eventData)
//	{
//		eventData.selectedObject = gameObject;
//		Debug.Log("Click: " + eventData.selectedObject.name);
//		ParticlesManager.Instance.PlaceAndPlayParticles(eventData.selectedObject.transform.position, EnemyColor);
//		gameObject.SetActive(false);
//	}

	void OnMouseDown()
	{
		Debug.Log("Click: " + transform.name);
		clicked = true;
		ParticlesManager.Instance.PlaceAndPlayParticles(transform.position, EnemyColor);
		gameObject.SetActive(false);
	}

	void ChangeEnemyType()
	{
		float chanse = Random.Range(0, 100) + UntouchableChanse;

		if(chanse > 95f && chanse < 100f)
		{
			CurrentEnemyType = EnemiesTypes.Gingerbeardman;
		}
		else if(chanse > 66f && chanse < 95f)
		{
			CurrentEnemyType = EnemiesTypes.IceCream;
		}
		else
		{
			CurrentEnemyType = EnemiesTypes.Mafin;
		}


		switch(CurrentEnemyType)
		{
			case EnemiesTypes.Mafin:
				enemyMeshRenderer.material.SetTexture("_MainTex", EnemiesTexturesList[0]);
				EnemyColor = new Color(1f, 0.5f, 0.25f);
			break;

			case EnemiesTypes.IceCream:
				enemyMeshRenderer.material.SetTexture("_MainTex", EnemiesTexturesList[1]);
				EnemyColor = new Color((139f / 255f), (198f / 255f), (73f / 255f));
			break;

			case EnemiesTypes.Gingerbeardman:
				enemyMeshRenderer.material.SetTexture("_MainTex", EnemiesTexturesList[2]);
				EnemyColor = new Color((234f / 255f), (74f / 255f), (52f / 255f));
			break;

			default:
				enemyMeshRenderer.material.SetTexture("_MainTex", EnemiesTexturesList[0]);
				EnemyColor = new Color(1f, 0.5f, 0.25f);
			break;
		}
	}

	void OnBecameInvisible()
	{
		if(CurrentEnemyType == EnemiesTypes.Gingerbeardman)
		{
			if(clicked)
			{
				Debug.Log("You clicker wrong guy!");
				GameManager.Instance.GoToLoseState();
			}
			else
			{
				gameObject.SetActive(false);
			}
		}
		else
		{
			if(!clicked)
			{
				Debug.Log("You missed one life!");
				GameManager.Instance.AjustPlayerLives (-1);
			}
		}
	}
}