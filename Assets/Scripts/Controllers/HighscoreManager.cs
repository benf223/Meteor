using UnityEngine;
using UnityEngine.UI;

public class HighscoreManager : MonoBehaviour
{
	public GameObject starPrefab;
	public Text[] highscoreTexts;
	public Collider2D collider;
	private int[] highscores;

	public int maxStars;
	private int currentStars;
	
	// Use this for initialization
	private void Start()
	{
		highscores = new int[5];
		LoadScores();
		WriteScores();

		currentStars = 0;
	}

	private void LoadScores()
	{
		highscores[0] = 1000000;
		highscores[1] = 100000;
		highscores[2] = 10000;
		highscores[3] = 1000;
		highscores[4] = 100;
	}

	private void WriteScores()
	{
		for (int i = 0; i < highscores.Length; ++i)
		{
			highscoreTexts[i].text = FormatNumber(highscores[i]);
		}
	}

	private string FormatNumber(int number)
	{
		return number.ToString("N0");
	}

	// Update is called once per frame
	private void Update()
	{
		if (Random.Range(1, 6) == 3)
			SpawnStar();
		
		if (Input.GetKeyDown(KeyCode.Escape))
			UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
	}

	private void SpawnStar()
	{
		if (currentStars >= maxStars)
			return;
		
		Bounds spawnBounds = collider.bounds;

		Vector3 min = spawnBounds.min;
		Vector3 max = spawnBounds.max;

		float x = Random.Range(min.x, max.x);
		float y = Random.Range(min.y, max.y);
		float scale = Random.RandomRange(1f, 1.3f);

		Vector2 spawnLocation = new Vector3(x, y, 0);

		GameObject spawned = Instantiate(starPrefab, spawnLocation, Quaternion.identity);
		spawned.GetComponent<StarController>().scale = scale;

		++currentStars;
	}

	public void StarDespawned()
	{
		--currentStars;
	}
}