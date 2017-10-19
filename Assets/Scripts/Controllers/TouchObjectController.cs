using UnityEngine;
using UnityEngine.UI;

/**
 * This script handles the touch objects spawned in the game
 * when the screen is touched.
 */
public class TouchObjectController : MonoBehaviour {
    
    // DECLARATION
    public GameObject touchManager;
    private TouchController touchController;
    private float startTime;
    private Rigidbody2D rb;

    // The Y position since creation
    private float initialY;

    // Extensions for the maxY and maxX to limit the swiping of up and down
    public float yPositionExtensionUp;
    public float yPositionExtensionDown;

    // Position of the touch object in the previous and current frame
    // Used for calculating the speed of the object
    private Vector2 previousPosition;
    private Vector2 currentPosition;

    // Distance between current frame and last frame
    private float speed;

    // Variable to store the touchable object this touch object is interacting with
    // Prevents the controlling of multiple meteorites in a single touch
    private GameObject touchableObject;

    // The force to apply spin to the object when swiped
    public float spinForce;

    // Use this for initialization
    private void Start() {
        // Finds reference to the touch manager to get the script (object)
        touchManager = GameObject.Find("TouchManager");
        touchController = touchManager.GetComponent<TouchController>();

        // To keep track of the when the touch object was spawned
        startTime = Time.timeSinceLevelLoad;

        // Get reference to the object's rigidbody2d
        rb = GetComponent<Rigidbody2D>();

        // References to the initial Y position of the object
        initialY = rb.position.y;
    }

    // Update is called once per frame
    private void Update() {
        /**
		 * Destroys the object when the drag time is reached
		 * or when the user stops dragging.
		 */
        if (Time.timeSinceLevelLoad > startTime + touchController.dragTime || !touchController.IsDragging()) {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate() {
        // Gets the position of the current frame
        currentPosition = transform.position;

        if (touchController.IsDragging()) {
            // Get the position of the touch
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);

            // Sets the position of this touch object to the position of the actual touch
            rb.position = touchPosition;

            // Doesn't allow swiping up
            if (touchPosition.y > initialY + yPositionExtensionUp) {
                Destroy(gameObject);
            }

            // Doesn't allow swiping down
            if (touchPosition.y < initialY - yPositionExtensionDown) {
                Destroy(gameObject);
            }
        }

        // Calculates the current speed of the touch object
        speed = Vector2.Distance(previousPosition, currentPosition);

        // If a meteorite exists in the touch, then move it
        if (touchableObject != null) {
            MoveObject();
        }

        // Technically saves the positition of the previous frame
        previousPosition = transform.position;
    }

    /**
	 * Function that controls the movement of the objects
	 * the touch object is interacting with.
	 */
    private void MoveObject() {
        // Referencing the needed controllers and components
        TouchableObjectController touchableObjectController = touchableObject.GetComponent<TouchableObjectController>();
        Transform touchableObjectTransform = touchableObject.GetComponent<Transform>();
        Rigidbody2D touchableObjectRb = touchableObject.GetComponent<Rigidbody2D>();

        /**
		 * First checks if the meteorite is currenty being interacted with,
		 * and if the meteorite HAS NOT already been touched.
		 */
        if (touchableObjectController.IsTouching() && touchableObjectController.touchCount >= 0) {
            // Calculating the force of the flick using the modifiable multiplier and speed of touch object
            float flickForce = touchController.flickForceMultiplier * speed;

            // Limits the max force allowed
            // To allow higher touch sensitivity, but not a huge force
            if (flickForce > touchController.maxFlickForce) {
                flickForce = touchController.maxFlickForce;
            }

            // Finally, applies the force to the meteorite towards the position of the touch object
            touchableObjectRb.AddForce((transform.position - touchableObjectTransform.position) * flickForce);
            touchableObjectRb.AddTorque((transform.position.x - touchableObjectTransform.position.x) * spinForce);

        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        /**
		 * This first if statement is to stop the touch object from
		 * interacting with multiple touch objects in a single swipe
		 */
        if (touchableObject == null) {

            // Sets which objects can be interacted with/swiped

            if (other.CompareTag("Meteorite")) {

                SetTouched(other);
            }

            if (other.CompareTag("ItemBox")) {

                SetTouched(other);
            }
        }
    }

    /**
	* Assigns the touch object with a touchable object
	* to interact with.
	* Also sets the touchable object in a touched state so that
	* it cannot be interacted with again after the swipe.
	*/
    private void SetTouched(Collider2D other) {

        // Gets reference to the collided object to obtain the script
        touchableObject = other.gameObject;
        TouchableObjectController touchableObjectController = touchableObject.GetComponent<TouchableObjectController>();

        // Apply the SetTouched function to the object that has been touched
        if (!touchableObjectController.IsTouching()) {
            touchableObjectController.SetTouched(gameObject);
        }
    }

    /**
	 * Returns the speed of the touch object.
	 */
    public float GetSpeed() {
        return speed;
    }
}