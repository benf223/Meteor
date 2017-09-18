using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    int score = 0;
    public GameObject difficultyManager;
    private DifficultyManagerController difficultyManagerControl;
	public Text scoreText;

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
	//this method is not being called (I know its just for later in case we decide we want it)
    public void AddScore()
    {
        score+=10;
        Debug.Log("Score: " + score);
        score++;
		scoreText.text = score.ToString ();
        //Debug.Log("Score: " + score);
    }
	/**
	 * This method is the current method being called to add to the score, which is now displayed on the screen
	 * */
    public void AddScore(int num)
	{
        score += num;
		scoreText.text = score.ToString ();
       // Debug.Log("Score: " + score);
        //Debug.Log("Score: " + score);
    }
}
		
