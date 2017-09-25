using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteDespawnerController : MonoBehaviour {
	public GameController gameCont;
	// Use this for initialization
	private void Start () {
		
	}
	
	// Update is called once per frame
	private void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Meteorite") {
			Destroy(other.gameObject);
			if (gameCont != null) {
				gameCont.AddScore(2);
			}
			
		}
	}
}
