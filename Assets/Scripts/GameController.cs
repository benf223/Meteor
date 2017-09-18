using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    int score = 0;
    bool gameOver;
    public Text gameOverText;
    public float resetDelay;
    float waitStartTime;

    // Use this for initialization
    void Start()
    {
        gameOver = false;
        gameOverText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //current time is bigger then destroyed time +5 secs (5 second delay)
        //and gameOver is true
        if (gameOver && Time.time > waitStartTime + resetDelay)
        {
            ResetGame();
        }
    }

    public void AddScore()
    {
        score++;
        Debug.Log("Score: " + score);
    }

    public void AddScore(int num)
    {
        score += num;
        Debug.Log("Score: " + score);
    }

    public void GameOver()
    {
        gameOver = true;
        gameOverText.gameObject.SetActive(true);
        waitStartTime = Time.time;//when the village is destroyed
       
    }

    private void ResetGame()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
