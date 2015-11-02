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
		Pumpkin,
		PumpkinTall,
		Ghost
	}

	public EnemiesTypes CurrentEnemyType;

	public float UntouchableChanse;

	public Color EnemyColor;
	public List<EnemyData> EnemiesVisualList = new List<EnemyData>();

	private MeshFilter enemyMeshFilter;
	private MeshRenderer enemyMeshRenderer;

	public float spawnedX;

	public bool Clicked = false;

	void Awake()
	{
		enemyTransform = transform;
		enemyMeshFilter = GetComponent<MeshFilter> ();
		enemyMeshRenderer = GetComponent<MeshRenderer>();

		runSate = new EnemyRunState(this);
	}

	void OnEnable()
	{
		currentSate = runSate;
		Clicked = false;
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
		if (GameStatesManager.Instance.currentGameState == GameStatesManager.Instance.levelGameState) {
			Debug.Log ("Click: " + transform.name);
			Clicked = true;
			ParticlesManager.Instance.PlaceAndPlayParticles (transform.position, EnemyColor);
			gameObject.SetActive (false);	
		}
		else
		{
			return;
		}
	}

	void ChangeEnemyType()
	{
		float chanse = Random.Range(0, 100) + UntouchableChanse;

		if(chanse > 95f && chanse < 100f)
		{
			CurrentEnemyType = EnemiesTypes.Ghost;
		}
		else if(chanse > 66f && chanse < 95f)
		{
			CurrentEnemyType = EnemiesTypes.PumpkinTall;
		}
		else
		{
			CurrentEnemyType = EnemiesTypes.Pumpkin;
		}


		switch(CurrentEnemyType)
		{
				case EnemiesTypes.Pumpkin:
				
				enemyMeshFilter.mesh = EnemiesVisualList [0].EnemyMesh;
				enemyMeshRenderer.material = EnemiesVisualList [0].EnemyMaterial;
				enemyMeshRenderer.material.SetTexture("_MainTex", EnemiesVisualList[0].EnemyTexture);

				EnemyColor = new Color(1f, 0.5f, 0.25f);
			break;

			case EnemiesTypes.PumpkinTall:

				enemyMeshFilter.mesh = EnemiesVisualList [1].EnemyMesh;
				enemyMeshRenderer.material = EnemiesVisualList [1].EnemyMaterial;
				enemyMeshRenderer.material.SetTexture("_MainTex", EnemiesVisualList[1].EnemyTexture);

				EnemyColor = new Color(1f, 0.5f, 0.25f);
			break;

			case EnemiesTypes.Ghost:
				enemyMeshFilter.mesh = EnemiesVisualList [2].EnemyMesh;
				enemyMeshRenderer.material = EnemiesVisualList [2].EnemyMaterial;
				enemyMeshRenderer.material.SetTexture("_MainTex", EnemiesVisualList[2].EnemyTexture);
			break;

			default:

				enemyMeshFilter.mesh = EnemiesVisualList [0].EnemyMesh;
				enemyMeshRenderer.material = EnemiesVisualList [0].EnemyMaterial;
				enemyMeshRenderer.material.SetTexture("_MainTex", EnemiesVisualList[0].EnemyTexture);

				EnemyColor = new Color(1f, 0.5f, 0.25f);
			break;
		}
	}

	void OnBecameInvisible()
	{
		if(CurrentEnemyType == EnemiesTypes.Ghost)
		{
			if(Clicked)
			{
				Debug.Log("You clicker wrong guy!");
				GameStatesManager.Instance.GoToLoseState();
			}
			else
			{
				gameObject.SetActive(false);
			}
		}
		else
		{
			if (!Clicked && (GameStatesManager.Instance.currentGameState != GameStatesManager.Instance.levelLoseState && GameStatesManager.Instance.currentGameState != GameStatesManager.Instance.levelWonState)) {
				Debug.Log ("You missed one life!");
				GameStatesManager.Instance.AjustPlayerLives (-1);
			}

			gameObject.SetActive (false);
		}
	}
}