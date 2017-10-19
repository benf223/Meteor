using UnityEngine;

public class ItemBoxController : TouchableObjectController
{
	public GameObject[] powerups;
	public Transform myTransform;

	/**
	 * Randomizes powerup selection
	 */
	public GameObject getRandomPowerup()
	{
		int min = 0;
		int max = powerups.Length; 				// Gets the max
		int choice = Random.Range(min, max); 	// Randomizes

		return powerups[choice]; 				// Returns
	}

	public void OnCollisionEnter2D(Collision2D other)
	{
		// If collided with Village
		if (other.gameObject.CompareTag("Village"))
		{
			// Only instantiate if powerup is already not active
			// Just incase multiple boxes in screen at once
			if (GameObject.FindWithTag("Powerup") == null)
			{
				Instantiate(getRandomPowerup(), new Vector3(0, 0, 0), Quaternion.identity);
				GameObject[] existingItemBoxes = GameObject.FindGameObjectsWithTag("ItemBox");

				foreach (GameObject itemBoxes in existingItemBoxes)
				{
					Destroy(itemBoxes);
				}
			}

			Destroy(gameObject);
		}
	}

	void FixedUpdate()
	{
		rb.AddTorque(-myTransform.rotation.z * 10);
	}
}