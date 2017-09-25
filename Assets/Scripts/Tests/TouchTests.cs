using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class TouchTests : MonoBehaviour
{
	private string sceneName;

	private bool menuFlag;
	private bool wasQuit;

	private bool gameEndFlag;

	private void Start()
	{
	    if (!Debug.isDebugBuild)
		    return;
	
		sceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;

		if (sceneName.Equals("Menu"))
		{
			GameObject.Find("Play Button").GetComponent<Button>().onClick.AddListener(() => PlayButtonListener());
			GameObject.Find("Quit Button").GetComponent<Button>().onClick.AddListener(() => QuitButtonListener());
		}
		
		if (PlayerPrefs.HasKey("touchTestGameEnded"))
		{
			PlayerPrefs.DeleteKey("touchTestGameEnded");
			
			Debug.Log(sceneName.Equals("Menu") ? "Touch Test: Game End test passed." : "Touch Test: Game End test failed.");
		}

		if (PlayerPrefs.HasKey("touchTestMenuChanged"))
		{
			PlayerPrefs.DeleteKey("touchTestMenuChanged");
			
			Debug.Log(sceneName.Equals("Game") ? "Touch Test: Menu test passed." : "Touch Test: Menu test passed");
		}
	}

	private void Update()
	{
		if (!Debug.isDebugBuild)
			return;
		
		switch (sceneName)
		{
			case "Menu":
			{
				MainMenuTests();
				break;
			}
			case "Game":
			{
				GamePlayTests();
				break;
			}
			case "GameEnd":
			{
				GameEndTests();
				gameEndFlag = false;
				break;
			}
			default:
			{
				Debug.LogError("Touch Test: Invalid Scene.");
				break;
			}
		}
	}

	private void MainMenuTests()
	{
		if (Input.touchCount > 0)
		{
			Debug.Log("Touch Test: Touch Detected.");
		}
	}
	
	private void PlayButtonListener()
	{
		menuFlag = true;
	}
	
	private void QuitButtonListener()
	{
		if (!Debug.isDebugBuild)
			return;
		
		menuFlag = true;
		wasQuit = true;
	}

	private void GamePlayTests()
	{
		if (Input.touchCount > 0)
		{
			Debug.Log("Touch Test: GamePlay Touch Detected.");

			GameObject[] meteors = GameObject.FindGameObjectsWithTag("Meteorite");

			if (meteors.Length != 0)
			{
				if (meteors.Any(meteor => meteor.GetComponent<MeteoriteController>().touching))
				{
					Debug.Log("Touch Test: GamePlay test passed.");
				}
			}
		}
	}

	private void GameEndTests()
	{
		if (Input.touchCount > 0)
		{
			Debug.Log("Touch Test: Game End Touch Detected.");
		}
	}
	
	public void GameEndListener()
	{
		gameEndFlag = true;
	}

	private void OnDestroy()
	{
		if (!Debug.isDebugBuild)
			return;
		
		if (gameEndFlag)
		{
			Debug.Log("Touch Test: Scene changing from Game End.");
			PlayerPrefs.SetInt("touchTestGameEnded", 1);
		}

		if (menuFlag)
		{
			if (wasQuit)
			{
				Debug.Log("Touch Test: Menu test passed");
				return;
			}
			
			Debug.Log("Touch Test: Scene changing from Menu");
			PlayerPrefs.SetInt("touchTestMenuChanged", 1);
		}
	}
}