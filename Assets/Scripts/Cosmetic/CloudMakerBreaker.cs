using UnityEngine;

public class CloudMakerBreaker : MonoBehaviour
{
	public GameObject cloud;
	public Collider2D cd;
	public float minSpawnTime = 0.5f;
	public float maxSpawnTime = 3.0f;
	public bool onLeft;
	
	private float spawnTimer;
	private float timeSinceLastSpawn;

	private void Start()
	{
		// Randomize the initial spawn time between
		RandomizeSpawnTime();
		timeSinceLastSpawn = Time.timeSinceLevelLoad;
	}

	/**
	 * Randomizes the spawn timer
	 */
	private void RandomizeSpawnTime()
	{
		spawnTimer = Random.Range(minSpawnTime, maxSpawnTime);
	}

	private void FixedUpdate()
	{
		if (Time.timeSinceLevelLoad >= (timeSinceLastSpawn + spawnTimer))
		{
			Bounds spawnBounds = cd.bounds;
			Vector3 min = spawnBounds.min;
			Vector3 max = spawnBounds.max;

			float x = Random.Range(min.x, max.x);
			float y = Random.Range(min.y, max.y);

			Vector2 spawnLocation = new Vector3(x, y, 0);
			GameObject o = Instantiate(cloud, spawnLocation, Quaternion.identity);

			CloudController tmp = o.GetComponent<CloudController>();
			tmp.direction = onLeft ? 1 : -1;

			timeSinceLastSpawn = Time.timeSinceLevelLoad;
			RandomizeSpawnTime();
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag.Equals("Cloud"))
		{
			CloudController a = other.GetComponent<CloudController>();

			if (a != null)
			{
				if (a.direction == 1 && !onLeft)
					Destroy(other.gameObject);
				else if (a.direction == -1 && onLeft)
					Destroy(other.gameObject);
			}
		}
	}
}