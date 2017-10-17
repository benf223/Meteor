﻿using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
	public GameObject itemBox;
	public GameObject difficultyManager;
	public float minSpawnForce;
	public float maxSpawnForce;
	public float spawnDelay = 5;

	private Collider2D cd;
	private float elapseTime;				//Spawn delay between item drops
	private float secondsToIncrease;

	// Use this for initialization
	void Start()
	{
		cd = GetComponent<BoxCollider2D>();
	}

	// Update is called once per frame
	void Update()
	{
		if (Time.timeSinceLevelLoad >= elapseTime)
		{
			elapseTime++;
			secondsToIncrease++;
		}
		
		spawnTime();
	}

	public void spawnTime()
	{
		if (secondsToIncrease == spawnDelay)
		{
			// Spawn item box with powerup is NOT already active
			if (GameObject.FindWithTag("Powerup") == null)
			{
				SpawnItemBox();
			}

			secondsToIncrease = 0;
		}
	}

	public void SpawnItemBox()
	{
		//get the bounding box of the box collider
		Bounds spawnBounds = cd.bounds;

		Vector3 min = spawnBounds.min; 		//get min values
		Vector3 max = spawnBounds.max; 		//get max values

		//randomize a position in the spawn area
		float x = Random.Range(min.x, max.x);
		float y = Random.Range(min.y, max.y);

		//instantiate the randomized location
		Vector2 spawnLocation = new Vector3(x, y, 0);

		//Create the object in the random position
		GameObject spawned = Instantiate(itemBox, spawnLocation, Quaternion.identity);
		Rigidbody2D rb = spawned.GetComponent<Rigidbody2D>();

		// Randomize between spawning to the left, or the right
		// 0 = right, 180 = left
		float angle;
		int randomNum = Random.Range(0, 2);
		
		if (randomNum == 0)
		{
			angle = 0;
		}
		else
		{
			angle = 180;
		}

		// Calculate the force to add
		float addedForce = Random.Range(minSpawnForce, maxSpawnForce);

		// Calculates the direction using the angle
		Vector3 dir = Quaternion.AngleAxis(angle, Vector3.up) * Vector3.right;

		// Finally, add the force to the direction.
		rb.AddForce(dir * addedForce);
	}
}