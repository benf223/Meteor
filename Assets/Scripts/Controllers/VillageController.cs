using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class VillageController : MonoBehaviour {
    public Sprite[] sprites;
    public GameObject[] destroyedVersions;
    public AudioClip audio;
    public GameObject difficultyManager;
    public AudioClip explosion;
    public bool isDestroyed;
    public bool godMode;
    public GameObject explosionObj;
    public GameObject particleExplosion;

    private DifficultyManagerController difficultyManagerController;
    private SpriteRenderer spriteRenderer;
    private int latestSeconds;
    private int growthCount;
    private float timer;

    // Use this for initialization
    private void Start() {
        //this is what makes it so that the sprite can be changed in run time not via animation, can be swapped
        //to animation later on
        spriteRenderer = GetComponent<Renderer>() as SpriteRenderer;

        growthCount = 0;
        UpdateCollider();

        if (Debug.isDebugBuild)
            Debug.Log("Village Created Succesfully");
    }

    // Update is called once per frame
    private void Update() {
        timer += Time.deltaTime;
        float seconds = timer % 60;
    }

    /**
	   * This method increases the size of the village sprite by .2 lengthwise for the first 20 seconds, and then
	   * .2 in height for the next 50, after this the village will not grow anymore. This can be altered later on 
	   * by simply changing the vector values and the amount of time in the update() method for this script
	 * 
	 * NOTE: This function is called within the difficulty manager controller to make sure it is called 100% of the time
	 * WILL NEED TO FIGURE OUT WHY IT WON'T CALL WHEN IN THE UPDATES 100% OF THE TIME
	   * */
    public bool IncreaseSize() {
        if (Debug.isDebugBuild)
            Debug.Log("Growed?");

        if (growthCount < 2) {
            if (Debug.isDebugBuild)
                Debug.Log("Village growth triggered!");

            spriteRenderer.sprite = sprites[growthCount + 1];
            growthCount++;

            if (Debug.isDebugBuild)
                Debug.Log("GROWTH COUNT: " + growthCount);

            UpdateCollider();
            return true;
        }

        return false;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Meteorite")) {
            if (!godMode) {
                MeteoriteController meteorite = collision.gameObject.GetComponent<MeteoriteController>();
                meteorite.BlowUp();
                GameController gameController = GameObject.Find("GameManager").GetComponent<GameController>();

                if (gameController != null) {
                    gameController.StartMenuTimer();
                }

                BlowUp(collision);
                PlayExplosion();
                isDestroyed = true;
            }
        }
    }

    private void BlowUp(Collision2D collision) {
        // Instantiate destroyed version
        Vector3 pos = GetComponent<Transform>().position;
        Instantiate(destroyedVersions[growthCount], pos, Quaternion.identity);

		// Instantiate explosion
        if (explosionObj != null) {
            ContactPoint2D contactPoint = collision.contacts[0];
            Vector2 explosionPoint = contactPoint.point;
            explosionPoint.y = collision.gameObject.GetComponent<Transform>().position.y - 0.5f;
            Instantiate(explosionObj, explosionPoint, Quaternion.identity);
            if (particleExplosion != null) {
                Instantiate(particleExplosion, explosionPoint, Quaternion.identity);
            }
			
			//explosionObj.GetComponent<ExplosionController>().particleExplosion.transform.localScale = new Vector3(1f, 1f, 0f);
        }


        // Destroy village gameObject
        Destroy(gameObject);
    }

    /**
	 * Updates the BoxCollider2D offset and size
	 * depending on the sprite's bounds set
	 * in the sprite editor.
	 */
    private void PlayExplosion() {
        AudioSource.PlayClipAtPoint(audio, transform.position);
    }

    /**
	 * Updates the BoxCollider2D offset and size
	 * depending on the sprite's bounds set
	 * in the sprite editor.
	 */
    private void UpdateCollider() {
        BoxCollider2D collider = GetComponent<BoxCollider2D>();

        // Gets the size and center of the sprite and applies it to the collider
        collider.size = spriteRenderer.sprite.bounds.size;
        collider.offset = spriteRenderer.sprite.bounds.center;
    }
}