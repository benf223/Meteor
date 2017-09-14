using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteDespawnerController : MonoBehaviour {
	public GameController gameCont;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Meteorite") {
			Destroy(other.gameObject);
			gameCont.AddScore (2);
<<<<<<< HEAD
			//Debug.Log ("Destroyed");
=======
			Debug.Log ("Destroyed");
>>>>>>> master
		}
	}
}
