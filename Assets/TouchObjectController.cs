using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchObjectController : MonoBehaviour {

	public GameObject touchManager;
	private TouchController touchController;
	private float startTime;
	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		touchManager = GameObject.Find("TouchManager");
		touchController = touchManager.GetComponent<TouchController>();
		startTime = Time.time;
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > startTime + touchController.dragTime || !touchController.IsDragging()) {
			Destroy(gameObject);
		}
	}

	void FixedUpdate() {
		if (touchController.IsDragging()) {
			Vector2 touchPosition = (Vector2)Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
			rb.position = touchPosition;
		}
	}
}
