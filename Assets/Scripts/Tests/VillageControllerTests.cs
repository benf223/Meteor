using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class VillageControllerTests {

	public VillageController villCont;
	public DifficultyManagerController diffCont;

	public void LoadMyScene() {
		UnityEngine.SceneManagement.SceneManager.LoadScene ("Test");

	}
	[UnityTest]
	public IEnumerator VillageControllerTestsSimplePasses() {
		LoadMyScene ();
		Assert.AreEqual (1, 1);
		Debug.Log ("jjjjj");
		yield return null;
	}
		
//	[UnityTest]
//	public IEnumerator TestVillageGrowthChangeSprite()
//	{
//		LoadMyScene ();
//
//		GameObject currObj = GameObject.Find("Village");
//		villCont = currObj.GetComponent<VillageController>();
//		Sprite sprite1 = currObj.GetComponent<SpriteRenderer> ().sprite;
//		villCont.IncreaseSize ();
//		GameObject nextObj = GameObject.Find("Village");
//		villCont = nextObj.GetComponent<VillageController>();
//		Sprite sprite2 = nextObj.GetComponent<SpriteRenderer> ().sprite;
//		yield return new WaitForFixedUpdate();
//		Assert.IsFalse(sprite1.Equals(sprite2));
//		//Assert.AreEqual(1,1);
//		//yield return null;
//	}

	// A UnityTest behaves like a coroutine in PlayMode
	// and allows you to yield null to skip a frame in EditMode
	[UnityTest]
	public IEnumerator VillageControllerTestsWithEnumeratorPasses() {
	
		yield return null;
	}

	[UnityTest]
	public IEnumerator VillageIsNotNull() {
		GameObject currObj = GameObject.Find("Village");
		villCont = currObj.GetComponent<VillageController>();
		Assert.IsNotNull (villCont);
		yield return null;
	}
}
