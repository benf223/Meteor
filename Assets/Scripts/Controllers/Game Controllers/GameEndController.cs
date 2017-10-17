﻿using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class GameEndController : MonoBehaviour
{
	public Text scoreText;
	public Text endText;
	public Text reminderText;
	public AudioMixer mixer;
	
	private bool update;
	private int timeToStop;
	
	// Use this for initialization
	public void Start()
	{
		mixer.SetFloat("sfxVolume", PlayerPrefs.GetInt("SFXVolume"));
		mixer.SetFloat("musicVolume", PlayerPrefs.GetInt("MusicVolume"));
		mixer.SetFloat("masterVolume", PlayerPrefs.GetInt("MasterVolume"));
		
		endText.fontSize = 2;
		update = true;
		timeToStop = (int) Time.timeSinceLevelLoad + 2;

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

		if (timeToStop <= (int) Time.timeSinceLevelLoad)
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