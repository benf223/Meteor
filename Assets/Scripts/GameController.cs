using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    int score = 0;
    public GameObject difficultyManager;
    private DifficultyManagerController difficultyManagerControl;

    // Use this for initialization
    void Start()
    {
        difficultyManagerControl = difficultyManager.GetComponent<DifficultyManagerController>();
        difficultyManagerControl.StartTimer();
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
        score++;
        //Debug.Log("Score: " + score);
    }

    public void AddScore(int num)
	{
        score += num;
       // Debug.Log("Score: " + score);
        //Debug.Log("Score: " + score);
    }
}
		
