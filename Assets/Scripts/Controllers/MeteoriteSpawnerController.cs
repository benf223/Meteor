using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteSpawnerController : MonoBehaviour
{
	public int amountSpawned {get; private set;}

	private Collider2D cd;
	public GameObject meteorite;
	public GameObject diffucltyManager;
	private DifficultyManagerController difficultyManagerController;

	public bool spawningEnabled = true;

	// Breath time for when to start the spawning of meteorites
	private float startSpawnTime = 0.75f;

	// Spawn delay between meteorites
	public float timeBetweenSpawn;

	// Minimum and maximum spawn force
	public float minSpawnForce;
	public float maxSpawnForce;

	// Testing tthe time for first spawn
	private float startTime;
	private float timeFirstSpawn = -1;


	// Use this for initialization
	private void Start()
	{
		startTime = Time.timeSinceLevelLoad;
		Debug.Log("Spawn Rate: " + timeBetweenSpawn);
		cd = GetComponent<BoxCollider2D>();
		difficultyManagerController = diffucltyManager.GetComponent<DifficultyManagerController>();
	}

	// Update is called once per frame
	private void Update()
	{
		// If difficulty has been updated, then update.
		if (difficultyManagerController.DifficultyUpdated())
		{
			// NOTE: Set time for spawn delay
			timeBetweenSpawn = difficultyManagerController.GetMeteoriteSpawnDelayMultiplier();
			Debug.Log("Spawn Rate: " + timeBetweenSpawn);
		}

		
	}

	private void FixedUpdate() {
		/**
		 * Start spawning meteorites when breathing time reached
		 * and then set the delay for spawn times between meteorites
		 */
		if (Time.timeSinceLevelLoad >= startSpawnTime)
		{
			SpawnMeteorites();
			startSpawnTime = Time.timeSinceLevelLoad + timeBetweenSpawn;

			/**
			 * For Testing
			 */
			if (timeFirstSpawn == -1) {
				timeFirstSpawn = Time.timeSinceLevelLoad;
				Debug.Log("Delay for first spawN: " + (timeFirstSpawn - startTime));
			}
		}
	}

	/**
	 * Function to controll the spawning of meteorites
	 */
	private void SpawnMeteorites()
	{
		// Gets the bounding box of the box collider
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
		// Debug.Log("Meteorite ID: " + spawned.GetInstanceID()+" | Spawn Location (x, y): " + "("+rb.position.x+". "+ rb.position.y+")");

		// Randomize between spawning to the left, or the right
		// 0 = right, 180 = left
		float angle = 180;
		int randomNum = Random.Range(0, 2);
		if (randomNum == 0) {
			angle = 0;
		} else {
			angle = 180;
		}

		// Calculate the force to add
		float addedForce = Random.Range(minSpawnForce, maxSpawnForce);
		
		// Calculates the direction using the angle
		// TBH, I have no idea how this actually works.
		Vector3 dir = Quaternion.AngleAxis(angle, Vector3.up) * Vector3.right;
		
		// Finally, add the force to the direction.
		rb.AddForce(dir * addedForce);
	}
}