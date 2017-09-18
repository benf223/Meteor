using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    int score = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
	//this method is not being called
    public void AddScore()
    {
        score+=10;
        Debug.Log("Score: " + score);
    }

    public void AddScore(int num)
	{
        score += num;
       // Debug.Log("Score: " + score);
    }
}
		
