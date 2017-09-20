﻿using UnityEngine;

public class MeteoriteController : MonoBehaviour {
    
	private GameObject difficultyManager;
	private DifficultyManagerController difficultyManagerController;
	private TouchController touchController;
	
	private Rigidbody2D rb;

	public float minGravityScale;
	public float maxGravityScale;

	public PhysicsMaterial2D lowBounce;

	private bool touching; // State in which meteorite is in process of flick
	private bool touched; // State in which meteorite HAS BEEN touched

	public float minBounciness;

	private GameObject touchObject;

	// Use this for initialization
	void Start () {
		touchController = GameObject.Find("TouchManager").GetComponent<TouchController>();
		touchObject = null;
		touched = false;
		touching = false;
		difficultyManager = GameObject.Find("DifficultyManager");
		difficultyManagerController = difficultyManager.GetComponent<DifficultyManagerController>();
		InitializeSpeed();
	}
	
	// Update is called once per frame
	void Update () {
		if (touching) {
			if (touchObject == null) {
				touched = true;
				touching = false;
			}
		}
	}

    public void BlowUp()
    {
        Destroy(gameObject);
    }

	private void InitializeSpeed() {
		rb = GetComponent<Rigidbody2D>();

		maxGravityScale *= difficultyManagerController.GetMeteoriteSpeedMultiplier();
		float gravityScale = Random.Range(minGravityScale, maxGravityScale);
		rb.gravityScale = gravityScale;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag("Touch") && !touched) {
			//SetTouched(other.gameObject);
		}
	}
	
	public void SetTouched(GameObject touchObject) {
		this.touchObject = touchObject;
		touching = true;
		gameObject.GetComponent<Renderer>().material.color = Color.gray; // Indicates when touched. Instead would need to change sprite when we actually have art
		CircleCollider2D cd = GetComponent<CircleCollider2D>();
		cd.sharedMaterial = lowBounce;
	}

	public bool IsTouching() {
		return touching;
	}

	public bool Touched() {
		return touched;
	}

	public void SetTouched(bool touched) {
		this.touched = touched;
	}
}
