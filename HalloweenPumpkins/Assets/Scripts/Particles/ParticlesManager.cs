using UnityEngine;
using System.Collections;

public class ParticlesManager : MonoBehaviour
{
	public static ParticlesManager Instance;

	public GameObject ParticlesPrefab;

	private GameObject particlesObject;
	private ParticleSystem particles;

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
}
