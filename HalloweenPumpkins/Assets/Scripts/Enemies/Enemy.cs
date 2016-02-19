using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class Enemy : MonoBehaviour
{
	public Transform enemyTransform;

	public enum EnemiesTypes
	{
		Pumpkin,
		PumpkinTall,
		Ghost
	}

	public EnemiesTypes CurrentEnemyType;

	public float spawnedPosX = 0;

	private float amplitudeX = 0.02f;
	private float frequency = 2.5f;
	public float fallingSpeed;

	private float xMovementPosition;
	private float yMovementPosition;

	public float UntouchableChanse;

	public Color EnemyColor;
	public List<EnemyData> EnemiesVisualList = new List<EnemyData>();

	private MeshFilter enemyMeshFilter;
	private MeshRenderer enemyMeshRenderer;

	public bool Clicked = false;

	void Awake()
	{
		enemyTransform = transform;
		enemyMeshFilter = GetComponent<MeshFilter> ();
		enemyMeshRenderer = GetComponent<MeshRenderer>();
	}

	void OnEnable()
	{
		Clicked = false;

		System.Random prng = new System.Random ();

		prng = new System.Random ();
		fallingSpeed = prng.Next (150, 300) * 0.01f;

		prng = new System.Random ();
		spawnedPosX = prng.Next (-150, 150) * 0.01f;
		enemyTransform.position = new Vector3 (spawnedPosX, 5f, 0);

		ChangeEnemyType ();
	}

	void Update ()
	{
		//x = a + b * sin(c * y + d);

		xMovementPosition = enemyTransform.position.x + amplitudeX * Mathf.Sin (frequency * enemyTransform.position.y + Time.time);
		yMovementPosition = enemyTransform.position.y - Time.deltaTime * fallingSpeed;
		enemyTransform.position = new Vector3(xMovementPosition, yMovementPosition, 0f);
	}

	void OnMouseDown()
	{
		if (GameStatesManager.Instance.currentGameState == GameStatesManager.Instance.levelGameState)
		{
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
		System.Random prng = new System.Random ();
		int enemyTypeRange = prng.Next(0, 100);

		Debug.Log (string.Format("<color=cyan>Chance: {0}</color>", enemyTypeRange));

		if(enemyTypeRange > 90f && enemyTypeRange < 100f)
		{
			CurrentEnemyType = EnemiesTypes.Ghost;
		}
		else if(enemyTypeRange > 66f && enemyTypeRange <= 90f)
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