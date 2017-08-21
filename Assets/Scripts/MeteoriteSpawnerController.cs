using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteSpawnerController : MonoBehaviour {

	private Collider2D cd;
	public GameObject meteorite;
	
	private float startSpawnTime = 1.0f;
	public float timeBetweenSpawn = 0.4f;


	// Use this for initialization
	void Start () {
		cd = GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time >= startSpawnTime) {
			SpawnMeteorites();
			startSpawnTime = Time.time + timeBetweenSpawn;
		}
	}

	void SpawnMeteorites() {
		Bounds spawnBounds = cd.bounds;

		Vector3 min = spawnBounds.min; // Get the minimum values
		Vector3 max = spawnBounds.max; // Get the maximum values

		// Randomize a position within the spawn area
		float x = Random.Range(min.x, max.x);
		float y = Random.Range(min.y, max.y);

		// Instantiate the randomized location
		Vector2 spawnLocation = new Vector3(x, y, 0);

		// Create the object in the random position
		GameObject spawned = Instantiate(meteorite, spawnLocation, Quaternion.identity);
		Rigidbody2D rb = spawned.GetComponent<Rigidbody2D>();

		// Randomize Angle
		float angle = Random.Range(0, 359);
		Vector3 dir = Quaternion.AngleAxis(angle, Vector3.up) * Vector3.right;
		rb.AddForce(dir * 150);
	}
}
