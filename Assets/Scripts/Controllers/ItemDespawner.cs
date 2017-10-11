using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDespawner : MonoBehaviour {
    public GameController gameController;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "ItemBox")
        {
            Destroy(other.gameObject);
        }
    }
}
