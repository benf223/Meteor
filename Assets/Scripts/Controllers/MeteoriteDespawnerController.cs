using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteDespawnerController : MonoBehaviour {
	public GameController gameCont;
	public AudioClip water;
	// Use this for initialization
	private void Start () {
		
	}
	
	// Update is called once per frame
	private void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Meteorite") {
			AudioSource.PlayClipAtPoint (water, transform.position);
			Destroy(other.gameObject);
			if (gameCont != null) {
				gameCont.AddScore(2);
			}
			
		}
	}
}
