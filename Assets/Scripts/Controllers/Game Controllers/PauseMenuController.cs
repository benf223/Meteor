using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
	private GameController gc;

	public void Start()
	{
		gameObject.SetActive(false);
		gc = GameObject.Find("GameManager").GetComponent<GameController>();
	}

	private void OnEnable()
	{
		GameObject.Find("PauseButton").SetActive(false);
	}

	private void OnDisable()
	{
		GameObject.Find("PauseButton").SetActive(true);
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
		//load the menu carefully
	}
}