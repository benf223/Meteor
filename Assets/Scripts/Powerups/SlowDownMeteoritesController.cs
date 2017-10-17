using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDownMeteoritesController : Powerup {
    public float slowedGravityScale;

    private MeteoriteSpawnerController spawnerController;

    new void Start()
    {
        spawnerController = GameObject.FindWithTag("MeteoriteSpawner").GetComponent<MeteoriteSpawnerController>();
        base.Start();
    }

    protected override void ActivatePowerup()
    {
        Debug.Log("Meteorites slowed down!");
        spawnerController.gravityScale = slowedGravityScale;
        Debug.Log(spawnerController.gravityScale);

        GameObject[] meteorites = GameObject.FindGameObjectsWithTag("Meteorite");
        if (meteorites != null)
        {
            foreach (GameObject m in meteorites)
            {
                m.GetComponent<Rigidbody2D>().gravityScale = slowedGravityScale;
            }
        }

    }

    protected override void DeactivatePowerup()
    {
        Debug.Log("Meteorites returned to normal speed");
        spawnerController.gravityScale = spawnerController.defaultGravityScale;
        GameObject[] meteorites = GameObject.FindGameObjectsWithTag("Meteorite");
        if (meteorites != null)
        {
            foreach (GameObject m in meteorites)
            {
                m.GetComponent<Rigidbody2D>().gravityScale = spawnerController.defaultGravityScale ;
            }
        }
        Destroy(gameObject);


    }
}
