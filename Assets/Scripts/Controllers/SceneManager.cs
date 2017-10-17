using System;
using UnityEngine;
using UnityEngine.Audio;

public class SceneManager : MonoBehaviour
{
	public AudioMixer mixer;
	
	private float time;

	private void Start()
	{
		mixer.SetFloat("sfxVolume", PlayerPrefs.GetInt("SFXVolume"));
		mixer.SetFloat("musicVolume", PlayerPrefs.GetInt("MusicVolume"));
		mixer.SetFloat("masterVolume", PlayerPrefs.GetInt("MasterVolume"));
		
	}

	public void PlayButtonPressed()
	{
		LoadScene("Game");
	}

	public void HighscoreButtonPressed()
	{
		LoadScene("Highscores");
	}

	public void SettingsButtonPressed()
	{
		LoadScene("Settings");
	}
	
	public void QuitButtonPressed()
	{
		Application.Quit();
	}

	private void LoadScene(String sceneName)
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
	}
}