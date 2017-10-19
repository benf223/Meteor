using UnityEngine;

public class MeteoriteController : TouchableObjectController {
    public GameObject explosion;

    public AudioClip bounce;
    public AudioClip water;

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Wall") && transform.position.y < 5) {
            gameObject.GetComponent<AudioSource>().clip = bounce;
            gameObject.GetComponent<AudioSource>().Play();
        }

        if (collision.gameObject.CompareTag("Village")) {
            if (explosion != null) {
                Instantiate(explosion, GetComponent<Transform>().position, Quaternion.identity);
            }
        }
    }

    public void SetGravityScale(float gs) {
        gameObject.GetComponent<Rigidbody2D>().gravityScale = gs;
    }


}