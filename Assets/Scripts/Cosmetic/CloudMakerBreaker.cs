using UnityEngine;

public class CloudMakerBreaker : MonoBehaviour
{
	public GameObject smol;
	public GameObject med;
	public GameObject large;
	public Collider2D collider;
	
	public bool onLeft;

	private void Update()
	{
		if (Random.Range(1, 200) == 17)
		{
			Bounds spawnBounds = collider.bounds;

			Vector3 min = spawnBounds.min;
			Vector3 max = spawnBounds.max;

			float x = Random.Range(min.x, max.x);
			float y = Random.Range(min.y, max.y);

			Vector2 spawnLocation = new Vector3(x, y, 0);
			GameObject o = gameObject;
			
			switch (Random.Range(0, 3))
			{
				case 0:
				{
					o = Instantiate(smol, spawnLocation, Quaternion.identity);
					break;
				}
				case 1:
				{
					o = Instantiate(med, spawnLocation, Quaternion.identity);
					break;
				}
				case 2:
				{
					o = Instantiate(large, spawnLocation, Quaternion.identity);
					break;
				}
			}

			CloudController tmp = o.GetComponent<CloudController>();
			tmp.direction = onLeft ? 1 : -1;
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
				{
					Destroy(other.gameObject);
				}
				else if (a.direction == -1 && onLeft)
				{
					Destroy(other.gameObject);
				}
			}
		}
	}
}