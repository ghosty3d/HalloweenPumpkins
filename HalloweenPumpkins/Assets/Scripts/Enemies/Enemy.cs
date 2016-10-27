using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class Enemy : MonoBehaviour
{
	public bool shouldStop = false;
	public bool clicked = false;
	public bool explosed = false;
	public bool exit = false;

	public Transform enemyTransform;

	public enum EnemiesTypes
	{
		Pumpkin,
		PumpkinTall,
		Ghost
	}

	public EnemiesTypes CurrentEnemyType;

	public float spawnedPosX = 0;

	private float amplitudeX = 0.03f;
	private float frequency = 2f;
	public float fallingSpeed;

	private float xMovementPosition;
	private float yMovementPosition;

	public float UntouchableChanse;

	private int minEnemySpeed = 200;
	private int maxEnemySpeed = 400;

	public Color EnemyColor;
	public List<EnemyData> EnemiesVisualList = new List<EnemyData>();

	private MeshFilter enemyMeshFilter;
	private MeshRenderer enemyMeshRenderer;

	public event System.Action OnDeath;

	void Awake()
	{
		enemyTransform = transform;
		enemyMeshFilter = GetComponent<MeshFilter> ();
		enemyMeshRenderer = GetComponent<MeshRenderer>();
	}

	void OnEnable()
	{
		clicked = false;
		explosed = false;
		exit = false;

		System.Random prng = new System.Random ();

		prng = new System.Random ();
		fallingSpeed = prng.Next (minEnemySpeed, maxEnemySpeed) * 0.01f * LevelsManager.Instance.CurrentLevel.speedEnemiesMultiplier;

		prng = new System.Random ();
		spawnedPosX = prng.Next (-150, 150) * 0.01f;
		enemyTransform.position = new Vector3 (spawnedPosX, 5f, 0);

		ChangeEnemyType ();
	}

	void Update ()
	{
		//x = a + b * sin(c * y + d);

		xMovementPosition = enemyTransform.position.x + amplitudeX * Mathf.Sin (frequency * enemyTransform.position.y + Time.deltaTime);
		yMovementPosition = enemyTransform.position.y - Time.deltaTime * fallingSpeed;

		if (!shouldStop) {
			enemyTransform.position = new Vector3(xMovementPosition, yMovementPosition, 0f);
		}
	}

	void OnMouseDown()
	{
		if (GameStatesManager.Instance.currentGameState == GameStatesManager.Instance.levelGameState)
		{
			clicked = true;
			ParticlesManager.Instance.PlaceAndPlayParticles (transform.position, EnemyColor);
			Debug.Log (string.Format("<color=magenta>{0} was killed by click!</color>", gameObject.name));
			gameObject.SetActive (false);

			if (CurrentEnemyType == EnemiesTypes.Ghost) {
				AudioManager.instance.PlayFailSound ();
			} else {
				AudioManager.instance.PlaySquashSound ();
			}
		}
	}

	void ChangeEnemyType()
	{
		System.Random prng = new System.Random ();
		int enemyTypeRange = prng.Next(0, 100);

		//Debug.Log (string.Format("<color=cyan>Chance: {0}</color>", enemyTypeRange));

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
		if (CurrentEnemyType == EnemiesTypes.Ghost) {
			if (clicked) {
				LevelsManager.Instance.userProgress.ghostStoped++;
				GameStatesManager.Instance.GoToLoseState();
			} else if(explosed) {
				#if UNITY_EDITOR
				Debug.Log (string.Format ("<color=orange>{0} was killed by Bomb!</color>", gameObject.name));
				#endif
				LevelsManager.Instance.userProgress.ghostExploded++;
				GameStatesManager.Instance.GoToLoseState();
			}
		} else {
			if (!clicked && !explosed && !exit) {
				Debug.Log ("You missed one life!");
				LevelsManager.Instance.userProgress.pumpkinsPassed++;
				GameStatesManager.Instance.AjustPlayerLives (-1);
			} else if (clicked) {				
				LevelsManager.Instance.userProgress.pumpkinsStoped++;
			} else if (explosed) {
				#if UNITY_EDITOR
				Debug.Log (string.Format ("<color=orange>{0} was killed by Bomb!</color>", gameObject.name));
				#endif
				LevelsManager.Instance.userProgress.pumpkinsExploded++;
			}
		}

		KillEnemy ();
	}

	protected void KillEnemy() {
		if (OnDeath != null) {
			OnDeath();
		}
		gameObject.SetActive (false);
	}
}