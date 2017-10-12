using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBreaker : Powerup {
    private GameObject[] walls;

    private float timeSinceStart;

    protected override void ActivatePowerup() {
        walls = GameObject.FindGameObjectsWithTag("Wall");

        foreach (GameObject a in walls) {
            a.GetComponent<Collider2D>().isTrigger = true;
        }
    }

    protected override void DeactivatePowerup() {
        foreach (GameObject a in walls) {
            a.GetComponent<Collider2D>().isTrigger = false;

        }
    }
}