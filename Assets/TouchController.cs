using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchController : MonoBehaviour {

    public GameObject touchObject;
    public Text debugText;

    public float flickForceMultiplier; // force of the flick
    public float dragTime; // in seconds, max duration of each flick
    public float maxFlickForce;

    private bool dragging;

    // Use this for initialization
    void Start() {
        dragging = false;
    }

    // Update is called once per frame
    void Update() {
        if (Input.touchCount == 1) {
            Touch touch = Input.GetTouch(0);
            GameObject anObject = null;
            if (touch.phase == TouchPhase.Began) {
                Vector2 touchPosition = touch.position;
                anObject = Instantiate(touchObject, (Vector2)Camera.main.ScreenToWorldPoint(touchPosition), Quaternion.identity);
                dragging = true;  
            }
            else if (touch.phase == TouchPhase.Moved) {
            } else if (touch.phase == TouchPhase.Ended) {
                dragging = false;
            }
        }
    }

    public bool IsDragging() {
        return dragging;
    }
}
