using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Powerup : MonoBehaviour {

	public float duration; // Duration of power up
	protected float startTime; // Just the start time. Not to be modifed
	public string powerupName; // Name of powerup 

	protected void Start() {
		// Sets the start time for the duration of the power up
		startTime = Time.timeSinceLevelLoad; 
		ActivatePowerup();
	}

	protected void Update() {
		// Once duration of powerup has been reached, reset all stats and deactivate (destroy) the powerup
		if ((Time.timeSinceLevelLoad - startTime) >= duration) {
			DeactivatePowerup();
			Destroy(gameObject);
		}
	}



	/**
	 * Values to change when power up is activated
	 */
	protected abstract void ActivatePowerup();

	/**
	 * Revert values back to default!
	 */
	protected abstract void DeactivatePowerup();
	
}
