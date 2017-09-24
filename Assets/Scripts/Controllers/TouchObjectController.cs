using UnityEngine;
using UnityEngine.UI;

public class TouchObjectController : MonoBehaviour
{
	public GameObject touchManager;
	private TouchController touchController;
	private float startTime;
	private Rigidbody2D rb;

	// The Y position since creation
	private float initialY; 

	// Extensions for the maxY and maxX
	public float yPositionExtensionUp;
	public float yPositionExtensionDown;

	// Position of the touch object in the previous and current frame
	// Used for calculating the speed of the object
	private Vector2 previousPosition;
	private Vector2 currentPosition;

	// Distance between current frame and last frame
	private float speed;

	// Variable to store the meteorite the object is interacting with
	// Prevents the controlling of multiple meteorites in a single touch
	private GameObject meteorite;

	// Use this for initialization
	void Start()
	{
		//foundMeteorite = false;
		touchManager = GameObject.Find("TouchManager");
		touchController = touchManager.GetComponent<TouchController>();
		startTime = Time.timeSinceLevelLoad;
		rb = GetComponent<Rigidbody2D>();
		initialY = rb.position.y;
	}

	// Update is called once per frame
	void Update()
	{
		/**
		 * Destroys the object when the drag time is reached
		 * or when the user stops dragging.
		 */
		if (Time.timeSinceLevelLoad > startTime + touchController.dragTime || !touchController.IsDragging())
		{
			Destroy(gameObject);
		}
	}

	void FixedUpdate()
	{	
		// Gets the position of the current frame
		currentPosition = transform.position;

		if (touchController.IsDragging())
		{
			// Get the position of the touch
			Vector2 touchPosition = (Vector2) Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);

			// Sets the position of this touch object to the position of the actual touch
			rb.position = touchPosition;

			// Doesn't allow swiping up
			if (touchPosition.y > initialY + yPositionExtensionUp)
			{
				Destroy(gameObject);
			}
			// Doesn't allow swiping down
			if (touchPosition.y < initialY - yPositionExtensionDown)
			{
				Destroy(gameObject);
			}
		}

		// Calculates the current speed of the touch object
		speed = Vector2.Distance(previousPosition, currentPosition);

		// If a meteorite exists in the touch, then move it
		if (meteorite != null)
		{
			MoveMeteorite();
		}

		// Technically saves the positition of the previous frame
		previousPosition = transform.position;
	}

	/**
	 * Function that controls the movement of the meteorite
	 * the touch object is interacting with.
	 */
	void MoveMeteorite()
	{	
		// Referencing the needed controllers and components
		MeteoriteController meteoriteController = meteorite.GetComponent<MeteoriteController>();
		Transform meteoriteTransform = meteorite.GetComponent<Transform>();
		Rigidbody2D meteoriteRb = meteorite.GetComponent<Rigidbody2D>();

		/**
		 * First checks if the meteorite is currenty being interacted with,
		 * and if the meteorite HAS NOT already been touched.
		 */
		if (meteoriteController.IsTouching() && !meteoriteController.Touched())
		{
			// Calculating the force of the flick using the modifiable multiplier and speed of touch object
			float flickForce = touchController.flickForceMultiplier * speed;

			// Limits the max force allowed
			// To allow higher touch sensitivity, but not a huge force
			if (flickForce > touchController.maxFlickForce)
			{
				flickForce = touchController.maxFlickForce;
			}

			// Finally, applies the force to the meteorite towards the position of the touch object
			meteoriteRb.AddForce((transform.position - meteoriteTransform.position) * flickForce);
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		/**
		 * This first if statement is to stop the touch object from
		 * interacting with multiple touch objects in a single swipe
		 */
		if (meteorite == null)
		{
			if (other.CompareTag("Meteorite"))
			{
				/**
				 * Assigns the touch object with a meteorite
				 * to interact with.
				 * Also sets the meteorite in a touched state so that
				 * it cannot be interacted with again after the swipe.
				 */
				meteorite = other.gameObject;
				meteorite.GetComponent<MeteoriteController>().SetTouched(gameObject);
			}
		}
	}
	
	/**
	 * Returns the speed of the touch object.
	 */
	public float GetSpeed()
	{
		return speed;
	}
}