using System;
using UnityEngine;
using UnityEngine.UI;

public class GameEndController : MonoBehaviour
{
	public Text scoreText;
	public Text endText;
	public Text reminderText;

	private bool update;
	private int count;

	private int timeToStop;
	
	// Use this for initialization
	public void Start()
	{
		endText.fontSize = 2;
		update = true;
		count = 0;
		timeToStop = (int) Time.timeSinceLevelLoad + 3;

		scoreText.text = PlayerPrefs.GetString("score");
	}

	// Update is called once per frame
	private void Update()	
	{
		if (update)
		{
			if (endText.fontSize != 150)
			{
				endText.fontSize = endText.fontSize + 1;
			}
		}
			
		update = !update;

		if (endText.fontSize == 60)
		{
			reminderText.color = Color.black;
		}

		if (timeToStop == (int) Time.timeSinceLevelLoad)
		{
			if (Input.touchCount == 1)
			{
				PlayerPrefs.SetString("score", "Score: 0");
			
				//This is a listener for the TouchTests class.
				if (Debug.isDebugBuild)
				{
					//Calls the listener.
					GameObject.Find("TestObject").GetComponent<TouchTests>().GameEndListener();
				}
			
				UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
			}
		}
	}
}