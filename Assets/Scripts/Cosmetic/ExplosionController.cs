using UnityEngine;

public class ExplosionController : MonoBehaviour
{
	public float lifeTime = 0.5f;
	public Rigidbody2D rb;
	public GameObject chosenExplosion;

	// Use this for initialization
	private void Start()
	{	
//		Instantiate(chosenExplosion, rb.position, Quaternion.identity);
		Invoke("Die", lifeTime);
	}

	// Destroys object
	private void Die()
	{	
		Destroy(gameObject);
	}


}