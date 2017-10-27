using UnityEngine.TestTools;
using System.Collections;

public class TestingSpawnDelay
{
	// A UnityTest behaves like a coroutine in PlayMode
	// and allows you to yield null to skip a frame in EditMode
	[UnityTest]
	public IEnumerator TestingSpawnDelayWithEnumeratorPasses()
	{
		SetUpScene();
		
		// Use the Assert class to test conditions.
		// yield to skip a frame
		yield return null;
	}

	public void SetUpScene()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("Test");
	}
}