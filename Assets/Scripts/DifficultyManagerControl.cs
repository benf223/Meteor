using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyManagerControl : MonoBehaviour
{
    private float startTimer;
    private float countTime;

    public bool timeFlowing;

    int hours;
    int minutes;
    int seconds;

    // Use this for initialization
    void Start()
    {
        timeFlowing = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeFlowing)
        {
            UpdateTime();
        }
    }

    int difficultyAlgorithm()
    {


        return 1;
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
