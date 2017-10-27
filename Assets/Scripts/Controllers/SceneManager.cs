using System;
using UnityEngine;
using UnityEngine.Audio;

public class SceneManager : MonoBehaviour
{
	public AudioMixer mixer;

	private float time;

	private void Start()
	{
		int tmp = PlayerPrefs.GetInt("SFXVolume");
		mixer.SetFloat("sfxVolume", tmp == -20 ? -80 : tmp);
		tmp = PlayerPrefs.GetInt("MusicVolume");
		mixer.SetFloat("musicVolume", tmp == -20 ? -80 : tmp);
		tmp = PlayerPrefs.GetInt("MasterVolume");
		mixer.SetFloat("masterVolume", tmp == -20 ? -80 : tmp);
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