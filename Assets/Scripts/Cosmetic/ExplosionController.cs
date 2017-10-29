using UnityEngine;

public class ExplosionController : MonoBehaviour
{
	public float lifeTime = 0.5f;
	public Rigidbody2D rb;
	public GameObject particleExplosion;

	// Use this for initialization
	private void Start()
	{	
		Instantiate(particleExplosion, rb.position, Quaternion.identity);
		Invoke("Die", lifeTime);
	}

	private void Die()
	{	
		Destroy(gameObject);
	}
}