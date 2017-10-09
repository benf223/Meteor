using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : MonoBehaviour
{

    private GameObject shield;
    private float timer;
    private float deltaTimer;

    // Use this for initialization
    void Start()
    {
        shield = GameObject.Find("Shield");
        timer = Time.time;
        deltaTimer = Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        // invoke repeating must be limited on the duration
        // must do timer and has to be less than the duration of 10 seconds
        // when the 5 seconds is up the flashes will do it more often (blue to yellow)
        // when 8 seconds is up the flash will increase even more (blue to red)
        CancelInvoke();
    }

    private void changeColour(int counter)
    {
        if (counter == 0)
        {
            shield.GetComponent<Renderer>().material.color = Color.blue;
        }
        else if (counter == 1)
        {
            shield.GetComponent<Renderer>().material.color = Color.yellow;
        }
        else if (counter == 2)
        {
            shield.GetComponent<Renderer>().material.color = Color.red;
        }
    }
}
