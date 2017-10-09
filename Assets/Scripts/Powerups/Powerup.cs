using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Powerup : MonoBehaviour {
	protected float duration;
	private float startTime;
	protected string powerupName;

	void Start() {
		startTime = Time.timeSinceLevelLoad;
		ActivatePowerup();
	}

	void Update() {
		if ((Time.timeSinceLevelLoad - startTime) >= duration) {
			DeactivatePowerup();
		}
	}

	protected abstract void ActivatePowerup();

	protected abstract void DeactivatePowerup();
}
