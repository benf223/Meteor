using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleTouchesPowerupController : Powerup {

    new void Start() {
        base.Start();
        this.duration = 10;
        this.powerupName = "Multiple Touches";
    }

    protected override void ActivatePowerup() {
        Debug.Log(powerupName + " is now Activated");
    }

    protected override void DeactivatePowerup() {
        Debug.Log(powerupName + " is now Deactivated");
    }
}
