using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
	public Slider music;
	public Slider sfx;
	public Slider master;
	public AudioMixer mixer;

	private int musicVolume;
	private int sfxVolume;
	private int masterVolume;
	private bool muted;
	private bool resettingHighscore;


	private void Start()
	{
		musicVolume = PlayerPrefs.GetInt("MusicVolume", 0);
		sfxVolume = PlayerPrefs.GetInt("SFXVolume", 0);
		masterVolume = PlayerPrefs.GetInt("MasterVolume", 0);

		mixer.SetFloat("sfxVolume", sfxVolume == -20 ? -80 : sfxVolume);
		mixer.SetFloat("musicVolume", musicVolume == -20 ? -80 : musicVolume);
		mixer.SetFloat("masterVolume", masterVolume == -20 ? -80 : masterVolume);

		music.value = musicVolume;
		sfx.value = sfxVolume;
		master.value = masterVolume;

		muted = PlayerPrefs.GetInt("Muted", 0) == 1;
	}

	
	public void OnMute()
	{
		if (muted)
		{
			music.value = 0;
			sfx.value = 0;
			master.value = 0;
		}
		else
		{
			music.value = -20;
			sfx.value = -20;
			master.value = -20;
		}

		muted = !muted;
	}

	public void ResetHighscores()
	{
		resettingHighscore = true;
	}

	public void Apply()
	{
		PlayerPrefs.SetInt("MusicVolume", (int) music.value);
		PlayerPrefs.SetInt("SFXVolume", (int) sfx.value);
		PlayerPrefs.SetInt("MasterVolume", (int) master.value);
		PlayerPrefs.SetInt("Muted", muted ? 1 : 0);

		if (resettingHighscore)
		{
			PlayerPrefs.SetInt("Highscore1", 0);
			PlayerPrefs.SetInt("Highscore2", 0);
			PlayerPrefs.SetInt("Highscore3", 0);
			PlayerPrefs.SetInt("Highscore4", 0);
			PlayerPrefs.SetInt("Highscore5", 0);
		}

		UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
			UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
	}
}