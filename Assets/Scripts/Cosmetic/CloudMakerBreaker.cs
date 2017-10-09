using UnityEngine;

public class CloudMakerBreaker : MonoBehaviour
{
	public GameObject smol;
	public GameObject med;
	public GameObject large;
	public Collider2D collider;
    public int spawnCounter;
    public int despawnCounter;
    public bool spawnEnabled;
	
	public bool onLeft;

    void Start()
    {
        spawnCounter = 0;
        despawnCounter = 0;
    }

	private void Update()
	{
        if (spawnEnabled)
        {
            spawnClouds();
        }
	}

    private void spawnClouds()
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
                        if (Debug.isDebugBuild)
                        {
                            Debug.Log("Small cloud is created");
                            Debug.Log("X position: " + x + " Y Position: " + y);
                            spawnCounter++;
                        }
                        break;
                    }
                case 1:
                    {
                        o = Instantiate(med, spawnLocation, Quaternion.identity);
                        if (Debug.isDebugBuild)
                        {
                            Debug.Log("Large cloud is created");
                            Debug.Log("X position: " + x + " Y position: " + y);
                            spawnCounter++;
                        }
                        break;
                    }
                case 2:
                    {
                        o = Instantiate(large, spawnLocation, Quaternion.identity);
                        if (Debug.isDebugBuild)
                        {
                            Debug.Log("Large cloud is created");
                            Debug.Log("X position: " + x + " Y Position: " + y);
                            spawnCounter++;
                        }
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
                    if (Debug.isDebugBuild)
                    {
                        Debug.Log("Cloud is destroyed on the right side");
                        despawnCounter++;
                    }
                }
				else if (a.direction == -1 && onLeft)
				{
					Destroy(other.gameObject);
                    if (Debug.isDebugBuild)
                    {
                        Debug.Log("Cloud is destroyed on the left side");
                        despawnCounter++;
                    }
                }
			}
		}
	}
}