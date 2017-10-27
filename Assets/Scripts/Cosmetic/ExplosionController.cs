using UnityEngine;

public class ExplosionController : MonoBehaviour
{
	public float lifeTime = 0.5f;
	public Rigidbody2D rb;

	// Use this for initialization
	private void Start()
	{
		Invoke("Die", lifeTime);
	}

	private void Die()
	{
		Destroy(gameObject);
	}
}