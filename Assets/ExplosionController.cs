using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour {

    public float lifeTime = 0.5f;
    public Rigidbody2D rb;

    private List<GameObject> collisions = new List<GameObject>();

    // Use this for initialization
    void Start() {
      Invoke("Die", lifeTime);
    }

    // Update is called once per frame
    void Update() {
        // foreach (GameObject go in collisions) {
        //     Rigidbody2D rb = go.GetComponent<Rigidbody2D>();
        //     Transform tf = go.GetComponent<Transform>();
        //    // Vector3 direction = GetComponent<Rigidbody2D>().position-rb.position; 
        //     rb.AddForce(tf.up * 100f);
           
        // }
    }

    private void Die() {
        Destroy(gameObject);
    }

    public void OnTriggerEnter2D(Collider2D other) {
    //    // TODO: FORLOOP FIND TOUCHED OBJECTS AND APPLY THAT FUCKING FORCE
    //     if (other.gameObject.CompareTag("Debris")) {
    //         if (!collisions.Contains(other.gameObject)) {
    //             collisions.Add(other.gameObject);
    //              Debug.Log(other.gameObject.name);
    //         }
    //     }

    }
}
