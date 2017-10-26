using UnityEngine;

/**
 * NOTES (things I did to make it work):
 * 1. The sprite of your cannon must point UPWARDS as it's the default direction for sprites in Unity. So rotate it in GIMP or something.
 * 2. Don't need that Constant Force component, as it's only for ONE direction. Better off changing the velocity in script.
 * 3. Make sure the balls have gravity scale. I noticed you had it at 0 before. May not be needed for the constant method.
 * 4. ANYTHING moving should have a Rigidbody component. Your cannon did not.
 * 5. Anything physics related, use FixedUpdate instead of Update
 */

/**
* OTHER NOTES:
* 1) This is your code, so change/modify whatever fits you best :)
* 2) Make sure to despawn the cannonballs after a period of time, or when it hits something like a wall or despawner.
* 3) Check the CannonBallController if you haven't already
	*/
	public class CannonController : Powerup {
	private GameObject cannon;
	public GameObject cannonBall;
	public GameObject wheel;
	//rpublic Transform spawn;
	private float timeSinceStart;
	//private float timer = 0;
	private float keepTrack = 0.2f;
	private float rotateTime = 2.0f;
	private Vector3 rotationDir = Vector3.forward * 10;
	private GameObject thisWheel;
	public CannonBallController cbc;

	protected override void ActivatePowerup() {
		cannon = GetComponent<GameObject>();
		transform.position = new Vector2(0.0f, -4.25f);
		Vector2 v2 = new Vector2(0.1f, -4.1f);
		thisWheel = (GameObject)Instantiate(wheel, v2, Quaternion.Euler(0f, 0f, 0f)) as GameObject;
		//wheel.SetActive (true);
		//wheel.transform.position = new Vector2 (0.16f, -4.1f);
	}

	protected override void DeactivatePowerup() {
		Destroy(cannon);
		Destroy(thisWheel);
	}

	// Whenever physics is involed, use FixedUpdate :)
	private void FixedUpdate() {
		UpdateVisibles();

		timeSinceStart = Time.timeSinceLevelLoad - startTime;
		if (timeSinceStart >= keepTrack) {
			if (timeSinceStart >= rotateTime) {
				rotateTime += 2f;
				rotationDir *= -1.0f;
			}

			// Initialize dem components
			Transform tf = GetComponent<Transform>();
			Rigidbody2D rb = GetComponent<Rigidbody2D>();

			// No idea how your rotation works, but okeh
			tf.Rotate(rotationDir);
			keepTrack += 0.2f;

			Debug.Log("SHOOT");

			GameObject thisBall;
			thisBall = (GameObject)Instantiate(cannonBall, rb.position, Quaternion.identity); //as GameObject; <- Same as casting.
			// Also, you can just use Quanterion.identity for default rotation

			/* UNCOMMENT FOR CONSTANT SPEED AND COMMENT OTHER ONE BELOW
			CannonBallController thisBallController = thisBall.GetComponent<CannonBallController>();
			// See function for details...
			thisBallController.SetConstant(10f, tf.up);
			 */

			// I like this one because physics, and realism... Cannon balls don't have constant force ;)
			// Up to you though, it's your cannon haha
			float force = 1000f;
			thisBall.GetComponent<Rigidbody2D>().AddForce(tf.up * force);

		}
	}
	public Vector3 CurrRot() {
		Vector2 vBarrelDir = new Vector2(transform.up.x, transform.up.y);
		return rotationDir;
	}

	public float GetTime() {
		Debug.Log("Called gettime())" + timeSinceStart);
		return timeSinceStart;
	}




}




