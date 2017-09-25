using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchController : MonoBehaviour {
    public GameObject touchObject;

    public float flickForceMultiplier; // force of the flick
    public float dragTime; // in seconds, max duration of each flick
    public float maxFlickForce; // Max flick force that can be applied to the touch object

    // To check if user still dragging or not to destroy the touch object
    private bool dragging;

    // Use this for initialization
	private void Start() {
        dragging = false;
    }

    // Update is called once per frame
	private void Update() {
        /**
		 * Calls when exactly 1 touch has been counted
		 */
        if (Input.touchCount == 1) {
            // Declared touch as variable
            Touch touch = Input.GetTouch(0);

            /**
			 * If the the screen has just been touched
			 * then find the position of the touch and
			 * create a touch object there.
			 */
            if (touch.phase == TouchPhase.Began) {
                Vector2 touchPosition = touch.position;
                Instantiate(touchObject, (Vector2)Camera.main.ScreenToWorldPoint(touchPosition), Quaternion.identity);

                dragging = true;
            }
            else if (touch.phase == TouchPhase.Moved) {
            }
            else if (touch.phase == TouchPhase.Ended) { // If the user has untouched the screen
                dragging = false;
            }
        }
    }

	/**
	 * Return the dragging boolean value
	 */
    public bool IsDragging() {
        return dragging;
    }
}