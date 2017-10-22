using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallController : MonoBehaviour {
	private Rigidbody2D rb;
	public CannonController cc;
	private float xVal = 0;
	// Use this for initialization
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Meteorite"))
		{
			Destroy(collision.gameObject);
			MeteoriteController meteorite = collision.gameObject.GetComponent<MeteoriteController>();
			Destroy (this.gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		//float t = cc.GetTime ();
		//Debug.Log ("TimeD: "+t);

		xVal = cc.GetTime ();
		Debug.Log ("Get" + xVal);
		rb = GetComponent<Rigidbody2D> ();
		Vector2 v = new Vector2(xVal, 100.0f);
		rb.AddForce(v);
	}
	public void Shoot() {
	}
}
