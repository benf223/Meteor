using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteSpawnerController : MonoBehaviour
{
	private Collider2D cd;
	public GameObject meteorite;
	public GameObject diffucltyManager;
	private DifficultyManagerController difficultyManagerController;

	private float startSpawnTime = 0.75f;
	public float timeBetweenSpawn;

	public float minSpawnForce;
	public float maxSpawnForce;


	// Use this for initialization
	void Start()
	{
		Debug.Log("Spawn Rate: " + timeBetweenSpawn);
		cd = GetComponent<BoxCollider2D>();
		difficultyManagerController = diffucltyManager.GetComponent<DifficultyManagerController>();
	}

	// Update is called once per frame
	void Update()
	{
		// If difficulty has been updated, then update.
		if (difficultyManagerController.DifficultyUpdated())
		{
			// NOTE: Set time for spawn delay
			timeBetweenSpawn = difficultyManagerController.GetMeteoriteSpawnDelayMultiplier();
			Debug.Log("Spawn Rate: " + timeBetweenSpawn);
		}

		if (Time.time >= startSpawnTime)
		{
			SpawnMeteorites();
			startSpawnTime = Time.time + timeBetweenSpawn;
		}
	}

	void SpawnMeteorites()
	{
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
		float angle = 0;
		int randomNum = Random.Range(0, 2);
		if (randomNum == 0) {
			angle = 0;
		} else {
			angle = 180;
		}

		float addedForce = Random.Range(minSpawnForce, maxSpawnForce);
		Vector3 dir = Quaternion.AngleAxis(angle, Vector3.up) * Vector3.right;
		rb.AddForce(dir * addedForce);
	}
}