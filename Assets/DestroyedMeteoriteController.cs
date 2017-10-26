using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyedMeteoriteController : MonoBehaviour {

	public float aliveTime = 7.5f;
	
	// Use this for initialization
	void Start () {
		Invoke("Despawn", aliveTime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Despawn() {
		Destroy(gameObject);
	}
}
