using UnityEngine;

public class MeteoriteController : MonoBehaviour
{
	private GameObject difficultyManager;
	private DifficultyManagerController difficultyManagerController;

	private Rigidbody2D rb;

	public float minGravityScale;
	public float maxGravityScale;

	public PhysicsMaterial2D lowBounce;
	public AudioClip audio;
	public AudioClip water;
	
	[HideInInspector]
	public bool touching; // State in which meteorite is in process of flick
	private bool touched; // State in which meteorite HAS BEEN touched

	private GameObject touchObject;

	// Use this for initialization
	private void Start()
	{
		touchObject = null;
		touched = false;
		touching = false;
		difficultyManager = GameObject.Find("DifficultyManager");
		if (difficultyManager != null)
		{
			difficultyManagerController = difficultyManager.GetComponent<DifficultyManagerController>();
		}

		InitializeSpeed();
	}

	// Update is called once per frame
	private void Update()
	{
		if (touching)
		{
			if (touchObject == null)
			{
				touched = true;
				touching = false;
			}
		}
	}

	private void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.CompareTag ("Wall") && transform.position.y < 5) {
			AudioSource.PlayClipAtPoint (audio, transform.position); 
		}
		if (collision.gameObject.CompareTag ("Despawner")) {
			AudioSource.PlayClipAtPoint (water, transform.position);
		}
	}

	public void BlowUp()
	{
		Destroy(gameObject);
	}

	private void InitializeSpeed()
	{
		rb = GetComponent<Rigidbody2D>();
		if (difficultyManagerController != null)
		{
			// Initial Gravity Scale
			maxGravityScale = difficultyManagerController.GetMeteoriteSpeedMultiplier();
			// Debug.Log("Max Meteorite Speed = " + maxGravityScale);
		}

		float gravityScale = Random.Range(minGravityScale, maxGravityScale);
		rb.gravityScale = gravityScale;
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Touch") && !touched)
		{
			//SetTouched(other.gameObject);
		}
	}

	public void SetTouched(GameObject touchObject)
	{
		this.touchObject = touchObject;
		touching = true;
		//	gameObject.GetComponent<Renderer>().material.color = Color.gray; // Indicates when touched. Instead would need to change sprite when we actually have art
		CircleCollider2D cd = GetComponent<CircleCollider2D>();
		cd.sharedMaterial = lowBounce;
	}

	public bool IsTouching()
	{
		return touching;
	}

	public bool Touched()
	{
		return touched;
	}

	public void SetTouched(bool touched)
	{
		this.touched = touched;
	}
}