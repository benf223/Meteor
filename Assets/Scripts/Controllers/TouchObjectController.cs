using UnityEngine;

public class TouchObjectController : MonoBehaviour
{
	public GameObject touchManager;
	private TouchController touchController;
	private float startTime;
	private Rigidbody2D rb;
	private float maxYUp; // The Y position of the object when created.

	private float maxYDown;

	// Extensions for the maxY and maxX
	public float yPositionExtensionUp;

	public float yPositionExtensionDown;


	private Vector2 previousPosition;
	private Vector2 currentPosition;
	private float speed;

	private GameObject meteorite;

	//private bool foundMeteorite;

	// Use this for initialization
	void Start()
	{
		//foundMeteorite = false;
		touchManager = GameObject.Find("TouchManager");
		touchController = touchManager.GetComponent<TouchController>();
		startTime = Time.time;
		rb = GetComponent<Rigidbody2D>();
		maxYUp = rb.position.y;
		maxYDown = rb.position.y;
	}

	// Update is called once per frame
	void Update()
	{
		if (Time.time > startTime + touchController.dragTime || !touchController.IsDragging())
		{
			Destroy(gameObject);
		}
	}

	void FixedUpdate()
	{
		currentPosition = transform.position;
		if (touchController.IsDragging())
		{
			// Get the position of the touch
			Vector2 touchPosition = (Vector2) Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
			// Sets the position of this touch object to the position of the actual touch
			rb.position = touchPosition;

			// Doesn't allow swiping up
			if (touchPosition.y > maxYUp + yPositionExtensionUp)
			{
				Destroy(gameObject);
			}
			// Doesn't allow swiping down
			if (touchPosition.y < maxYUp - yPositionExtensionDown)
			{
				Destroy(gameObject);
			}
		}
		speed = Vector2.Distance(previousPosition, currentPosition);

		if (meteorite != null)
		{
			MoveMeteorite();
		}

		previousPosition = transform.position;
	}

	void MoveMeteorite()
	{
		MeteoriteController meteoriteController = meteorite.GetComponent<MeteoriteController>();
		Transform meteoriteTransform = meteorite.GetComponent<Transform>();
		Rigidbody2D meteoriteRb = meteorite.GetComponent<Rigidbody2D>();
		if (meteoriteController.IsTouching() && !meteoriteController.Touched())
		{
			float flickForce = touchController.flickForceMultiplier * speed;
			if (flickForce > touchController.maxFlickForce)
			{
				flickForce = touchController.maxFlickForce;
			}
			meteoriteRb.AddForce((transform.position - meteoriteTransform.position) * flickForce);
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (meteorite == null)
		{
			if (other.CompareTag("Meteorite"))
			{
				meteorite = other.gameObject;
				meteorite.GetComponent<MeteoriteController>().SetTouched(gameObject);
			}
		}
	}

	public float GetSpeed()
	{
		return speed;
	}
}