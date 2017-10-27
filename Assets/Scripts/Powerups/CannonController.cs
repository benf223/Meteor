using UnityEngine;

public class CannonController : Powerup
{
	public GameObject cannonBall;
	public CannonBallController cbc;
	public GameObject wheel;

	private Vector3 rotationDir = Vector3.forward * 10;
	private GameObject thisWheel;
	private GameObject cannon;
	private float keepTrack = 0.2f;
	private float rotateTime = 2.0f;
	private float timeSinceStart;

	protected override void ActivatePowerup()
	{
		cannon = GetComponent<GameObject>();
		transform.position = new Vector2(0.0f, -4.25f);
		Vector2 v2 = new Vector2(0.1f, -4.1f);
		thisWheel = Instantiate(wheel, v2, Quaternion.Euler(0f, 0f, 0f));
	}

	protected override void DeactivatePowerup()
	{
		Destroy(cannon);
		Destroy(thisWheel);
	}

	// Whenever physics is involed, use FixedUpdate :)
	private void FixedUpdate()
	{
		UpdateVisibles();

		timeSinceStart = Time.timeSinceLevelLoad - startTime;
		if (timeSinceStart >= keepTrack)
		{
			if (timeSinceStart >= rotateTime)
			{
				rotateTime += 4f;
				rotationDir *= -1.0f;
			}

			// Initialize dem components
			Transform tf = GetComponent<Transform>();
			Rigidbody2D rb = GetComponent<Rigidbody2D>();

			// No idea how your rotation works, but okeh
			tf.Rotate(rotationDir);
			keepTrack += 0.2f;

			if (Debug.isDebugBuild)
				Debug.Log("SHOOT");

			GameObject thisBall;
			thisBall = Instantiate(cannonBall, rb.position, Quaternion.identity);

			float force = 1000f;
			thisBall.GetComponent<Rigidbody2D>().AddForce(tf.up * force);
		}
	}

	public Vector3 CurrRot()
	{
		Vector2 vBarrelDir = new Vector2(transform.up.x, transform.up.y);
		return rotationDir;
	}

	public float GetTime()
	{
		if (Debug.isDebugBuild)
			Debug.Log("Called gettime())" + timeSinceStart);
		
		return timeSinceStart;
	}
}