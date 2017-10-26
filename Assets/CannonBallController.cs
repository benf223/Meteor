using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallController : MonoBehaviour {
	private Rigidbody2D rb;
	public CannonController cc;
	private float xVal = 0;

	[HideInInspector]
	public bool constant = false;
	public float speed;
	public Vector3 direction;

	// Use this for initialization
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Meteorite"))
		{
			Destroy(collision.gameObject);
			MeteoriteController meteorite = collision.gameObject.GetComponent<MeteoriteController>();
			Destroy (this.gameObject);
		}
		if(collision.gameObject.CompareTag("Wall") )
		{
				Destroy (this.gameObject);
		}
	}

	void Start() {
		rb = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate() {
		// Applies a constant velocity
		if (constant) {
			rb.velocity = direction * speed;
		}
	}

	/**
	 * Sets a constant speed for the balls.
	 * @param speed The desired ball speed
	 * @param direction The desired direction
	 * Note: Should be called from the cannon.
	 */
	public void SetConstant(float speed, Vector3 direction) {
		constant = true;
		this.speed = speed;
		this.direction = direction;
	}

	public void Shoot() {
	}
}

