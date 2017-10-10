using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
	public GameObject pauseButton;
	private GameController gc;

	public void Start()
	{
		gameObject.SetActive(false);
		gc = GameObject.Find("GameManager").GetComponent<GameController>();
	}

	private void OnEnable()
	{
		if (Time.timeSinceLevelLoad > 0.2f)
		{
			pauseButton.SetActive(false);
		}
	}

	private void OnDisable()
	{
		pauseButton.SetActive(true);
	}

	public void OnResumePressed()
	{
		Time.timeScale = 1;
		gameObject.SetActive(false);
	}

	public void OnRestartPressed()
	{
		gc.restarting = true;
		UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
	}

	public void OnQuitPressed()
	{
        gc.restarting = true;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
	}
}