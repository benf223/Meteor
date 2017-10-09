using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class CloudUnitTesting {

	[Test]
	public void CloudUnitTestingSimplePasses() {
		// Use the Assert class to test conditions.
	}

	// A UnityTest behaves like a coroutine in PlayMode
	// and allows you to yield null to skip a frame in EditMode
	[UnityTest]
	public IEnumerator CloudUnitTestingWithEnumeratorPasses() {
        setUpScene();//sets up the clouds sppawning and despawning

        //let it spawn clouds for 10 seconds
		yield return new WaitForSeconds(10);

        //establishes GameObjects for each spawner
        GameObject cloudSpawnerLeft = GameObject.Find("Cloud Spawner Left");
        GameObject cloudSpawnerRight = GameObject.Find("Cloud Spawner Right");

        //stops both spawners from spawning more clouds
        CloudMakerBreaker left = cloudSpawnerLeft.GetComponent<CloudMakerBreaker>();
        left.enabled = false;

        CloudMakerBreaker right = cloudSpawnerRight.GetComponent<CloudMakerBreaker>();
        right.enabled = false;

        //wait another 10 seconds to allow time for the clouds to despawn
        yield return new WaitForSeconds(10);

        //The tests will check to see if they spawn the same amount as the despawn
        bool testOne = (left.spawnCounter == right.despawnCounter);
        bool testTwo = (right.spawnCounter == left.despawnCounter);

        Assert.AreEqual(testOne, testTwo);
    }

    //loads the CloudTest scene
    private void setUpScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("CloudTest");
    }
}
