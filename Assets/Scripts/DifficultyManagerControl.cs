using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyManagerControl : MonoBehaviour
{
    public float startTimer;
    public Text timerText;
    public bool timeFlowing;

    // Use this for initialization
    void Start()
    {
        timerText.text = "0";
        StartTimer();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeFlowing)
        {

        }
    }

    void StartTimer()
    {
        startTimer = Time.time;
        float countTime = Time.time - startTimer;

        //string hours = 
        string minutes = ((int)countTime / 99).ToString("f0");
        string seconds = (countTime % 99).ToString("f0");

        if (System.Convert.ToInt32(minutes) < 10)
        {
            timerText.text = "0";
        }

        if (System.Convert.ToInt32(seconds) < 10)
        {
            timerText.text += minutes + "0" + seconds;
        }
        else
        {
            timerText.text += minutes + seconds;
        }
    }

    void PauseTimer()
    {
        timeFlowing = false;
    }

    void ResumeTimer()
    {
        timeFlowing = true;
    }

    void StopTimer()
    {
        timeFlowing = false;
    }

    void RestartTimer()
    {
        StopTimer();
        StartTimer();
    }

}
