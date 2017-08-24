using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillageController : MonoBehaviour {

    public bool isDestroyed = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
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
