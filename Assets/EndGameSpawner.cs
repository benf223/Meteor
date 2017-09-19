using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EndGameSpawner : MonoBehaviour
{
	public GameObject meteorite;
	
	private Collider2D cd;
	private bool spawn;
	
	void Start()
	{
		spawn = false;
		cd = GetComponent<BoxCollider2D>();
	}

	void Update()
	{
		if (spawn)
		{
			SpawnMeteorites();
		}

		spawn = !spawn;
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
		float angle = Random.Range(0, 359);
		Vector3 dir = Quaternion.AngleAxis(angle, Vector3.up) * Vector3.right;
		rb.AddForce(dir * 150);
	}
}