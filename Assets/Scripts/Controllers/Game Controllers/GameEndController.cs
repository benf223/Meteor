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
	
	// Use this for initialization
	public void Start()
	{
		endText.fontSize = 2;
		update = true;
		count = 0;

		scoreText.text = PlayerPrefs.GetString("score");
	}

	// Update is called once per frame
	void Update()	
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

		if (Input.touchCount == 1)
		{
			PlayerPrefs.SetString("score", "Score: 0");
			UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
		}
	}
}