using UnityEngine;
using System.Collections;

public class BombObject : MonoBehaviour
{
	public SphereCollider DamageZone;
	public float RotationSpeed = 20f;
	public float BombTimer;
	public float BombRadius;
	private bool explosed = false;

	void OnEnable ()
	{
		StartCoroutine (BadaBoom(BombTimer));
		DamageZone.enabled = false;
	}

	void Update()
	{
		transform.Rotate (transform.up * RotationSpeed * Time.deltaTime);
	}
	
	IEnumerator BadaBoom(float timer)
	{
		while(explosed != true)
		{
			yield return new WaitForSeconds (timer);
			explosed = true;
			Explose ();
			Destroy (this.gameObject, 0.1f);
		}
	}

	public void Explose()
	{
		Debug.Log ("Explose");
		DamageZone.enabled = true;
		DamageZone.isTrigger = true;
		DamageZone.radius = BombRadius;

		//Particles
		ParticlesManager.Instance.PlaceBombParticles(transform.position);
		StopCoroutine ("BadaBoom");
	}

	void OnTriggerEnter(Collider other)
	{
		Debug.Log ("OnTriggerEnter");
		if(other.CompareTag("Enemy"))
		{
			other.gameObject.GetComponent<Enemy> ().Clicked = true;
			other.gameObject.SetActive (false);
		}
	}
}
