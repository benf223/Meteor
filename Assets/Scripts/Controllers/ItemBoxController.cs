using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBoxController : TouchableObjectController {

    public GameObject[] powerups;

    /**
     * Randomizes powerup selection
     */
    public GameObject getRandomPowerup() {
        int min = 0;
        int max = powerups.Length; // Gets the max

        int choice = Random.Range(min, max); // Randomizes

        return powerups[choice]; // Returns
    }

    public void OnCollisionEnter2D(Collision2D other) {
        // If collided with Village
        if (other.gameObject.CompareTag("Village")) {
            // Only instantiate if powerup is already not active
            // Just incase multiple boxes in screen at once
            if (GameObject.FindWithTag("Powerup") == null) {
                Instantiate(getRandomPowerup(), new Vector3(0, 0, 0), Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }
}
