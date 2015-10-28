using UnityEngine;
using System.Collections;

public class ParticlesManager : MonoBehaviour
{
	public static ParticlesManager Instance;

	public GameObject ParticlesPrefab;
	public GameObject BombParticlesPrefab;
	public GameObject VortexParticlesPrefab;

	private GameObject particlesObject;
	private GameObject bombParticlesObject;

	//
	private ParticleSystem particles;
	private ParticleSystem bombParticles;

	void Awake()
	{
		Instance = this;
	}

	void Start()
	{
		CreateParticles();
	}

	public void CreateParticles()
	{
		bombParticlesObject = Instantiate(BombParticlesPrefab, Vector3.zero, Quaternion.identity) as GameObject;
		bombParticles = bombParticlesObject.GetComponent<ParticleSystem>();

		particlesObject = Instantiate(ParticlesPrefab, Vector3.zero, Quaternion.identity) as GameObject;
		particles = particlesObject.GetComponent<ParticleSystem>();
	}

	public void PlaceAndPlayParticles(Vector3 position, Color particlesColor)
	{
		particlesObject.transform.position = position;
		particlesObject.SetActive(true);

		particles.startColor = particlesColor;
		particles.Play();

	}

	public void PlaceBombParticles(Vector3 position)
	{
		bombParticlesObject.transform.position = position;
		bombParticlesObject.SetActive(true);
		bombParticles.Play();

	}
}
