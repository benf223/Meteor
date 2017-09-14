using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteController : MonoBehaviour {
    
	private GameObject difficultyManager;
	private DifficultyManagerController difficultyManagerController;

	private Rigidbody2D rb;

	public float minGravityScale;
	public float maxGravityScale;


	// Use this for initialization
	void Start () {
		difficultyManager = GameObject.Find("DifficultyManager");
		difficultyManagerController = difficultyManager.GetComponent<DifficultyManagerController>();
		InitializeSpeed();
=======
	// Use this for initialization
	void Start () {
		
>>>>>>> master
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void BlowUp()
    {
<<<<<<< HEAD
        // Debug.Log("boom");
        Destroy(gameObject);
    }

	private void InitializeSpeed() {
		rb = GetComponent<Rigidbody2D>();

		maxGravityScale *= difficultyManagerController.GetMeteoriteSpeedMultiplier();
		float gravityScale = Random.Range(minGravityScale, maxGravityScale);
		rb.gravityScale = gravityScale;

		Debug.Log("Min Gravity Scale: "+ minGravityScale);
		Debug.Log("Max Gravity Scale: "+ maxGravityScale);
		Debug.Log("Gravity Scale: " + rb.gravityScale);
	}

	
=======
        Debug.Log("boom");
        Destroy(gameObject);
    }
>>>>>>> master
}
