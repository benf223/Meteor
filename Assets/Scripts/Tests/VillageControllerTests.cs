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
		
	[UnityTest]
	public IEnumerator TestVillageGrowthChangeSprite()
	{
		LoadMyScene ();
		yield return new WaitForFixedUpdate();
		GameObject currObj = GameObject.Find("Village");
		villCont = currObj.GetComponent<VillageController>();
		Sprite sprite1 = currObj.GetComponent<SpriteRenderer> ().sprite;
		villCont.IncreaseSize ();
		GameObject nextObj = GameObject.Find("Village");
		villCont = nextObj.GetComponent<VillageController>();
		Sprite sprite2 = nextObj.GetComponent<SpriteRenderer> ().sprite;
		yield return new WaitForFixedUpdate();
		Assert.IsFalse(sprite1.Equals(sprite2));

	}

	[UnityTest]
	public IEnumerator TestVillageGrowInSize() 
	{
		LoadMyScene ();
		yield return new WaitForFixedUpdate ();
		GameObject currObj = GameObject.Find("Village");
		villCont = currObj.GetComponent<VillageController>();
		Vector3 size1 = villCont.GetComponent<BoxCollider2D> ().bounds.size;
		villCont.IncreaseSize ();
		GameObject nextObj = GameObject.Find("Village");
		villCont = nextObj.GetComponent<VillageController>();
		Vector3 size2 = villCont.GetComponent<BoxCollider2D> ().bounds.size;
		yield return new WaitForFixedUpdate ();
		Assert.AreNotEqual (size1, size2);
		Debug.Log (size1 + " " + size2);

	}

	// A UnityTest behaves like a coroutine in PlayMode
	// and allows you to yield null to skip a frame in EditMode
	[UnityTest]
	public IEnumerator VillageControllerTestsWithEnumeratorPasses() {
	
		yield return null;
	}

	[UnityTest]
	public IEnumerator VillageIsNotNull() {
		LoadMyScene ();
		yield return new WaitForFixedUpdate ();
		GameObject currObj = GameObject.Find("Village");
		villCont = currObj.GetComponent<VillageController>();
		Assert.IsNotNull (villCont);
		yield return null;
	}
}
