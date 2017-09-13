using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyManagerControl : MonoBehaviour
{
    private float startTimer;
    private float countTime;

    // condition to keep the time continuing
    public bool timeFlowing;

    // time
    private int hours;
    private int minutes;
    private int seconds;

    // used to minus the duration time frames
    private int timeRemoved;

    private double spawnDelay;
    private double speedMultiplier;

    // Use this for initialization
    void Start()
    {
        timeFlowing = false;

        timeRemoved = 0;
        spawnDelay = 0.75f;
        speedMultiplier = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeFlowing)
        {
            UpdateTime();
        }
    }

    public bool DifficultyTimeFrame()
    {
        // does 20, 19, 18, 17, 16, 15 all the way to 10 seconds it changes difficulty
        if (seconds == (20 - timeRemoved))
        {
            if (timeRemoved <= 10)
                timeRemoved++;
            Debug.Log("Difficulty Time Frame Activated");
            return true;
        }
        else
        {
            return false;
        }
    }

    // NOTE THIS CAN CHANGE
    // this decreases from 0.75 to 0.25 using 0.05 for every difficulty time frame.
    public double MeteoriteSpawnDelayMultiplier()
    {
        // when 30 seconds is up this condition hits
        if (DifficultyTimeFrame() && spawnDelay >= 0.25f)
        {
            spawnDelay -= 0.05f;
            Debug.Log("Meteor spawn delay decreased");
        }

        return spawnDelay;
    }

    // NOTE THIS CAN CHANGE
    // this increases from 1.0 to 2.0 using 0.05 for every difficulty time frame.
    public double MeteoriteSpeedMultiplier()
    { 
        // when 20 seconds is up this condition hits
        if (DifficultyTimeFrame() && speedMultiplier <= 2.0f)
        {
            speedMultiplier += 0.05f;
            Debug.Log("Meteor speed increased");
        }

        return speedMultiplier;
    }

    public void StartTimer()
    {
        timeFlowing = true;
        startTimer = Time.time;
    }

    public void UpdateTime()
    {
        countTime = Time.time - startTimer;

        hours = ((int)countTime / 360);
        minutes = ((int)countTime / 60);
        seconds = ((int)countTime % 60);
    }

    public void PauseTimer()
    {
        timeFlowing = false;
    }

    public void ResumeTimer()
    {
        timeFlowing = true;
        startTimer = Time.time - countTime;
    }

    public void ResetTimer()
    {
        timeFlowing = false;
        countTime = 0;
    }
}
