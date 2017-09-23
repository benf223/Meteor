using System.Collections;
using UnityEngine;
using NUnit.Framework;
using UnityEditor.SceneManagement;
using UnityEngine.TestTools;
using Random = System.Random;

public class ScoreCarryOverTest
{
	public int score;
	
	[Test]
	public void ScoreCarryOverTestSimplePasses()
	{
		Random rand = new Random();
		
		// Use the Assert class to test conditions.
		GameController gc = GameObject.Find("GameManager").GetComponent<GameController>();

		if (gc != null)
		{
			gc.AddScore(rand.Next());
			score = gc.GetScore();
			gc.StoreScore();
		}

		EditorSceneManager.OpenScene("Assets/Scenes/GameEnd.unity");
		
		GameEndController ge = GameObject.Find("GameEndControl").GetComponent<GameEndController>();

		if (ge != null)
		{
			ge.Start();
			Assert.AreEqual("Score: " + score, ge.scoreText.text);
		}
	}
	
	//nuuuu
	[UnityTest]
	public IEnumerator ScoreCarryOverTestWithEnumeratorPasses()
	{
		// Use the Assert class to test conditions.
		// yield to skip a frame
		yield return null;
	}
}