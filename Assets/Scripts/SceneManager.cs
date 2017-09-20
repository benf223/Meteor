using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
	public void PlayButtonPressed()
	{
		LoadScene("Game");
	}

	public void Quit()
	{
		Application.Quit();
	}

	private void LoadScene(String sceneName)
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
	}
}