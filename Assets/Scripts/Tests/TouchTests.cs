using System.Linq;
using UnityEngine;
using UnityEngine.UI;

//Only run in a development build.
public class TouchTests : MonoBehaviour
{
	private string sceneName;

	private bool menuFlag;
	private bool wasQuit;

	private bool gameEndFlag;

	private void Start()
	{
		//Checks if it is a development build. If it isn't a Debug build it won't setup the tests.
	    if (!Debug.isDebugBuild)
		    return;
	
		//Stores the current scene name.
		sceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;

		//Checks if the scene name is 'Menu'.
		if (sceneName.Equals("Menu"))
		{
			//If we are in the Menu we will add listeners to the buttons for the tests.
			GameObject.Find("Play Button").GetComponent<Button>().onClick.AddListener(() => PlayButtonListener());
			GameObject.Find("Quit Button").GetComponent<Button>().onClick.AddListener(() => QuitButtonListener());
		}
		
		//Checks for the flag that is set by the Game Ended test.
		if (PlayerPrefs.HasKey("touchTestGameEnded"))
		{
			//Removes the flag.
			PlayerPrefs.DeleteKey("touchTestGameEnded");
			
			//This test passes if we have changed from the 'GameEnd' scene to the 'Menu' scene after a touch is registered.
			Debug.Log(sceneName.Equals("Menu") ? "Touch Test: Game End test passed." : "Touch Test: Game End test failed.");
		}

		//Checks for the flag that is set by the Menu test.
		if (PlayerPrefs.HasKey("touchTestMenuChanged"))
		{
			//Removes the flag.
			PlayerPrefs.DeleteKey("touchTestMenuChanged");
			
			//This test passes if we have changed from the 'Menu' scene to the 'Game' scene when the 'Play' button is pressed.
			Debug.Log(sceneName.Equals("Game") ? "Touch Test: Menu test passed." : "Touch Test: Menu test passed");
		}
	}

	//Tests are attempted run every frame.
	private void Update()
	{
		//Checks if it is a development build. If it isn't a Debug build it won't run the tests.
		if (!Debug.isDebugBuild)
			return;
		
		//Chooses which test to run based on the loaded scene.
		switch (sceneName)
		{
			case "Menu":
			{
				//Runs the tests for the 'Menu' scene.
				MainMenuTests();
				break;
			}
			case "Game":
			{
				//Runs the tests for the 'Game' scene.
				GamePlayTests();
				break;
			}
			case "GameEnd":
			{
				//Runs the tests for the 'GameEnd' scene.
				GameEndTests();
				
				//Initialises the flag for the test.
				gameEndFlag = false;
				break;
			}
			case "Settings":
			case "Highscores":
			{
				break;
			}
			default:
			{
				//If the scene has not been registered for the tests.
				Debug.LogError("Touch Test: Invalid Scene.");
				break;
			}
		}
	}

	private void MainMenuTests()
	{
		//Detects if touches are being registered in the scene.
		if (Input.touchCount > 0)
		{
			Debug.Log("Touch Test: Touch Detected.");
		}
	}
	
	//Called when the 'Play' button in the 'Menu' scene is pressed.
	private void PlayButtonListener()
	{
		//Checks if it is a development build. If it isn't a Debug build it won't run the tests.
		if (!Debug.isDebugBuild)
			return;
		
		//Sets the flag for the 'Menu' tests to be run.
		menuFlag = true;
	}
	
	//Called when the 'Quit' button in the 'Menu' scene is pressed.
	private void QuitButtonListener()
	{
		//Checks if it is a development build. If it isn't a Debug build it won't run the tests.
		if (!Debug.isDebugBuild)
			return;
		
		//Sets the flags for the 'Menu' tests to be run.
		menuFlag = true;
		wasQuit = true;
	}

	private void GamePlayTests()
	{
		//Detects if touches are being registered in the scene.
		if (Input.touchCount > 0)
		{
			Debug.Log("Touch Test: GamePlay Touch Detected.");
			
			//Retrieves all active 'Meteorites' in the scene.
			GameObject[] meteors = GameObject.FindGameObjectsWithTag("Meteorite");

			//Checks if there are 'Meteorites'
			if (meteors.Length != 0)
			{
				//Checks if any of the 'Meteorites' have registered a touch.
				if (meteors.Any(meteor => meteor.GetComponent<MeteoriteController>().touching))
				{
					//This test passes if a 'Meteorite' has registered a touch.
					Debug.Log("Touch Test: GamePlay test passed.");
				}
			}
		}
	}

	private void GameEndTests()
	{
		//Detects if touches are being registered in the scene.
		if (Input.touchCount > 0)
		{
			Debug.Log("Touch Test: Game End Touch Detected.");
		}
	}
	
	//Called by the GameEndController class when the screen is touched.
	public void GameEndListener()
	{
		//Sets the flag for the 'GameEnd' tests.
		gameEndFlag = true;
	}

	//Called when this object is being destroyed. Generally called when the scene is being changed.
	private void OnDestroy()
	{
		//Checks if it is a development build. If it isn't a Debug build it won't run the tests.
		if (!Debug.isDebugBuild)
			return;
		
		//Checks the 'GameEnd' test flag.
		if (gameEndFlag)
		{
			//If the flag is set the test is being commenced and the scene is being changed.
			Debug.Log("Touch Test: Scene changing from Game End.");
			
			//The flag is set for the 'GameEnd' test. This flag persists over scene changes.
			PlayerPrefs.SetInt("touchTestGameEnded", 1);
			
			return;
		}
		
		//Checks the 'Menu' test flag.
		if (menuFlag)
		{
			//If the 'Quit' button was pressed in the 'Menu' scene.
			if (wasQuit)
			{
				//The test passes if the scene is being destroyed after the 'Quit' button is pressed.
				Debug.Log("Touch Test: Menu test passed");
				return;
			}
			
			//If the 'Play' button was pressed instead of the 'Quit' button the test is being commenced and the scene is changing.
			Debug.Log("Touch Test: Scene changing from Menu");
			
			//The flag is set for the 'Menu' test. This flag persists over scene changes.
			PlayerPrefs.SetInt("touchTestMenuChanged", 1);
			
			return;
		}
		
		//If the scene is being closed but no tests have been initiated this performs a clean-up
		PlayerPrefs.DeleteKey("touchTestMenuChanged");
		PlayerPrefs.DeleteKey("touchTestGameEnded");
	}
}