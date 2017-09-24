using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class SpawnerTest {

	[Test]
	public void SpawnerTestSimplePasses() {
		// Use the Assert class to test conditions.
	}

	// A UnityTest behaves like a coroutine in PlayMode
	// and allows you to yield null to skip a frame in EditMode
	[UnityTest]
	public IEnumerator SpawnerTestDespawnCountEqualsSpawnCount() {
		// Setup the scene
		SetupScene();

		// Meteorites start spawning on default
		// Wait 10 seconds before stopping the spawn
		yield return new WaitForSeconds(10);
		MeteoriteSpawnerController spawner = GameObject.Find("MeteoriteSpawner").GetComponent<MeteoriteSpawnerController>();
		spawner.spawningEnabled = false;

		// Wait 5 seconds for remaining meteorites to drop.
		yield return new WaitForSeconds(5);

		// Get values of spawned and despawned amounts
		int spawned = spawner.amountSpawned;
		int despawned = GameObject.Find("MeteoriteDespawner").GetComponent<MeteoriteDespawnerController>().amountDespawned;

		Debug.Log("Spawned = "+spawned+"\nDespawned = "+ despawned);
		
		// Test if both values are equal
		Assert.AreEqual(spawned, despawned);

		yield return null;
	}

	/**
	 * Function to load the test scene
	 */
	private void SetupScene() {
		UnityEngine.SceneManagement.SceneManager.LoadScene("Spawn Test");
	}
}

