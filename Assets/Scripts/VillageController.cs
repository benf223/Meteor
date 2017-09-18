using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillageController : MonoBehaviour {

    public bool isDestroyed = false;
	private float xValue = 1.372662f;
	private float yValue = 0.0305513f;
	public DifficultyManagerController  diff;
	private int latestSeconds = 0;
	private int growthCount = 0;

	// Use this for initialization
	void Start () {
		
		
	}

	// Update is called once per frame
	void Update () {
		int curr = diff.GetSeconds();
		if (curr >= 5 + latestSeconds) {
			IncreaseSize ();
			latestSeconds = curr;
		}
	}
	/**
	 * This method increases the size of the village sprite by .2 lengthwise for the first 20 seconds, and then
	 * .2 in height for the next 50, after this the village will not grow anymore. This can be altered later on 
	 * by simply changing the vector values and the amount of time in the update() method for this script
	 * */
	public void IncreaseSize() {
		Debug.Log ("Village growth triggered!");
		if (growthCount < 4) {
			this.gameObject.transform.localScale += new Vector3 (0.2f, 0.0f, 0.0f);
		} else if(growthCount < 14){
			this.gameObject.transform.localScale += new Vector3 (0.0f, 0.2f, 0.0f);
		}
		growthCount++;
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Meteorite"))
        {
            MeteoriteController meteorite = collision.gameObject.GetComponent<MeteoriteController>();
            meteorite.BlowUp();
            isDestroyed = true;
            Destroy(gameObject);
        }
    }
}
