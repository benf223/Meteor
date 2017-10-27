using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class HighscoreManager : MonoBehaviour
{
	public GameObject starPrefab;
	public Text[] highscoreTexts;
	public Collider2D cd;
	public AudioMixer mixer;
	public int maxStars;
	
	private int currentStars;
	private int[] highscores;
	
	// Use this for initialization
	private void Start()
	{
		int tmp = PlayerPrefs.GetInt("SFXVolume");
		mixer.SetFloat("sfxVolume", tmp == -20 ? -80 : tmp);
		tmp = PlayerPrefs.GetInt("MusicVolume");
		mixer.SetFloat("musicVolume", tmp == -20 ? -80 : tmp);
		tmp = PlayerPrefs.GetInt("MasterVolume");
		mixer.SetFloat("masterVolume", tmp == -20 ? -80 : tmp);

		highscores = new int[5];

		LoadScores();
		WriteScores();

		currentStars = 0;
	}

	private void LoadScores()
	{
		highscores[0] = PlayerPrefs.GetInt("Highscore1", 0);
		highscores[1] = PlayerPrefs.GetInt("Highscore2", 0);
		highscores[2] = PlayerPrefs.GetInt("Highscore3", 0);
		highscores[3] = PlayerPrefs.GetInt("Highscore4", 0);
		highscores[4] = PlayerPrefs.GetInt("Highscore5", 0);
	}

	private void WriteScores()
	{
		for (int i = 0; i < highscores.Length; ++i)
			highscoreTexts[i].text = FormatNumber(highscores[i]);
	}

	private string FormatNumber(int number)
	{
		return number.ToString("N0");
	}

	// Update is called once per frame
	private void Update()
	{
		if (Random.Range(1, 20) == 3)
			SpawnStar();

		if (Input.GetKeyDown(KeyCode.Escape))
			UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
	}

	private void SpawnStar()
	{
		if (currentStars >= maxStars)
			return;

		Bounds spawnBounds = cd.bounds;

		Vector3 min = spawnBounds.min;
		Vector3 max = spawnBounds.max;

		float x = Random.Range(min.x, max.x);
		float y = Random.Range(min.y, max.y);
		float scale = Random.Range(1f, 1.3f);

		Vector2 spawnLocation = new Vector3(x, y, 0);

		GameObject spawned = Instantiate(starPrefab, spawnLocation, Quaternion.identity);
		spawned.GetComponent<StarController>().scale = scale;

		++currentStars;
	}

	public void StarDespawned()
	{
		--currentStars;
	}

	public void BackButtonPressed()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
	}
}