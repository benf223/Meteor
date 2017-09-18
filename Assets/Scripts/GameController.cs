using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    int score = 0;
    public Text gameOverText;

    // Use this for initialization
    void Start()
    {
        gameOverText.gameObject.SetActive(false);
        StartCoroutine(MyCoroutine());
    }

    // Update is called once per frame
    void Update()
    {

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

    IEnumerator MyCoroutine()
    {
        yield return new WaitForSeconds(10);
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        // float waitStartTime = Time.time;
        

        Application.LoadLevel(Application.loadedLevel);
    }
}
