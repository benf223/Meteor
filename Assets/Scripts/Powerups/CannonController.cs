using UnityEngine;

public class CannonController : Powerup
{
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

	protected override void ActivatePowerup()
	{
		cannon = GetComponent<GameObject> ();
		transform.position = new Vector2(0.0f, -4.25f);
		Vector2 v2 = new Vector2 (0.1f, -4.1f);
		thisWheel = (GameObject)Instantiate (wheel, v2, Quaternion.Euler (0f, 0f, 0f)) as GameObject;
		//wheel.SetActive (true);
		//wheel.transform.position = new Vector2 (0.16f, -4.1f);
	}

	protected override void DeactivatePowerup()
	{
		Destroy (cannon);
		Destroy (thisWheel);
	}

	private new void Update()
	{
		UpdateVisibles();

		timeSinceStart = Time.timeSinceLevelLoad - startTime;
		if (timeSinceStart >= keepTrack) {
			if (timeSinceStart >= rotateTime) {
				rotateTime += 2;
				rotationDir *= -1.0f;
			}
			transform.Rotate (rotationDir);
			keepTrack += 0.2f;
			Debug.Log ("SHOOT");
			//cannonBall.transform.position = new Vector2 (0.0f, -4.109f);
			Vector2 v = new Vector2 (0.0f, -4.109f);
			GameObject thisBall;
			thisBall = (GameObject)Instantiate(cannonBall, v, Quaternion.Euler(0.0f,0.0f,0.0f)) as GameObject;
			cbc.Shoot ();
			//thisBall.transform.Rotate (rotationDir);
			//thisBall.rigidbody.AddForce(Vector3.forward * 10000);
			//thisBall.GetComponent<Rigidbody> ().AddForce (Vector3.forward * 10000);

		}

		if (Time.timeSinceLevelLoad - startTime >= duration)
		{
			DeactivatePowerup();
			DeactivateSlider();
			Destroy(gameObject);
		}
	}
	public Vector3 CurrRot() {
		Vector2 vBarrelDir = new Vector2(transform.up.x,transform.up.y);
		return rotationDir;
	}

	public float GetTime() {
		Debug.Log ("Called gettime())"+timeSinceStart);
		return timeSinceStart;
	}




}


