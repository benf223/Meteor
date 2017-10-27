using UnityEngine;

public class CannonBallController : MonoBehaviour
{
	[HideInInspector] public bool constant;
	
	public float speed;
	public Vector3 direction;
	public CannonController cc;
	public GameObject explosion;
	
	private Rigidbody2D rb;
	private float xVal = 0;
	
	// Use this for initialization
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Meteorite"))
		{
			MeteoriteController mc = collision.gameObject.GetComponent<MeteoriteController>();
			mc.BlowUp();
			ContactPoint2D contactPoint = collision.contacts[0];
			Vector2 explosionPoint = contactPoint.point;
			Instantiate(explosion, explosionPoint, Quaternion.identity);
			MeteoriteController meteorite = collision.gameObject.GetComponent<MeteoriteController>();
			Destroy(gameObject);
		}
		if (collision.gameObject.CompareTag("Wall"))
		{
			Destroy(gameObject);
		}
	}

	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate()
	{
		// Applies a constant velocity
		if (constant)
			rb.velocity = direction * speed;
	}

	/**
	   * Sets a constant speed for the balls.
	   * @param speed The desired ball speed
	   * @param direction The desired direction
	   * Note: Should be called from the cannon.
	   */
	public void SetConstant(float speed, Vector3 direction)
	{
		constant = true;
		this.speed = speed;
		this.direction = direction;
	}

	public void Shoot()
	{
	}
}