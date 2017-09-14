using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    int score = 0;
<<<<<<< HEAD
    public GameObject diffucltyManager;
    private DifficultyManagerController difficultyManagerControl;
=======
>>>>>>> master

    // Use this for initialization
    void Start()
    {
<<<<<<< HEAD
        difficultyManagerControl = diffucltyManager.GetComponent<DifficultyManagerController>();
        difficultyManagerControl.StartTimer();
=======

>>>>>>> master
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddScore()
    {
        score++;
<<<<<<< HEAD
        //Debug.Log("Score: " + score);
=======
        Debug.Log("Score: " + score);
>>>>>>> master
    }

    public void AddScore(int num)
    {
        score += num;
<<<<<<< HEAD
        //Debug.Log("Score: " + score);
=======
        Debug.Log("Score: " + score);
>>>>>>> master
    }
}
