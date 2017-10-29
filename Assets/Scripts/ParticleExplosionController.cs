using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleExplosionController : MonoBehaviour {

	ParticleSystem ps;

	// Use this for initialization
	void Start () {
		ps = (ParticleSystem)GetComponentInChildren(typeof(ParticleSystem));
	}
	
	// Update is called once per frame
	void Update () {
		Destroy(gameObject, ps.main.duration);
	}
}
