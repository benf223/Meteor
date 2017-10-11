using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleTouchesPowerupController : Powerup {

    public int touchCount;
    private MeteoriteSpawnerController spawnerController;
    GameObject test;

    new void Start() {
        spawnerController = GameObject.FindWithTag("MeteoriteSpawner").GetComponent<MeteoriteSpawnerController>();
        base.Start();
    }

    protected override void ActivatePowerup() {
        Debug.Log(powerupName + " is now Activated");
        spawnerController.touchCount = touchCount;
    }

    protected override void DeactivatePowerup() {
        Debug.Log(powerupName + " is now Deactivated");
        spawnerController.touchCount = spawnerController.defaultTouchCount;
        Destroy(gameObject);
    }
}
