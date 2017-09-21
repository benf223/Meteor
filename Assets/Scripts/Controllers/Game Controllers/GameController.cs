using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private int score;
    private DifficultyManagerController difficultyManagerControl;
	
	public GameObject difficultyManager;
	public Text scoreText;
	
    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1f;
	    score = 0;
	    difficultyManagerControl = difficultyManager.GetComponent<DifficultyManagerController>();
        difficultyManagerControl.StartTimer();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
        }
    }

    public void AddScore()
    {
	    AddScore(10);
    }

    public void AddScore(int num)
    {
	    score += num;
	    scoreText.text = "Score: " + score;
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetString("score", "Score: " + score);
        difficultyManagerControl.PauseTimer(); // maybe 
    }
}
