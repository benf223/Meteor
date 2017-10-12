using UnityEngine;

public class MeteoriteDespawnerController : MonoBehaviour {
    public GameController gameCont;
    public AudioClip water;
    // Use this for initialization
    private void Start() {

    }

    // Update is called once per frame
    private void Update() {

    }
    public int amountDespawned { get; private set; }
    public bool despawnItemBoxes = true;

    private void OnTriggerEnter2D(Collider2D other) {
        AudioSource.PlayClipAtPoint(water, transform.position);
        if (other.gameObject.tag.Equals("Meteorite")) {
            Destroy(other.gameObject);

            if (gameCont != null) {
                gameCont.AddScore(2);
            }
        }

        if (despawnItemBoxes && other.gameObject.CompareTag("ItemBox")) {
            Destroy(other.gameObject);
        }
    }
}