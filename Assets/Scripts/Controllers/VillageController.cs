using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class VillageController : MonoBehaviour {
    private DifficultyManagerController difficultyManagerController;
    public Sprite[] sprites;
    public GameObject[] destroyedVersions;
    public AudioClip audio;
	public GameObject difficultyManager;
	public AudioClip explosion;
	public bool isDestroyed;
	public bool godMode;
	
	private SpriteRenderer spriteRenderer;
	private int latestSeconds;
	private int growthCount;
	private float timer;

	// Use this for initialization
	private void Start()
	{
		//this is what makes it so that the sprite can be changed in run time not via animation, can be swapped
		//to animation later on
		spriteRenderer = GetComponent<Renderer>() as SpriteRenderer;

		growthCount = 0;
		UpdateCollider();

		if (Debug.isDebugBuild)
			Debug.Log("Village Created Succesfully");
	}

    // Update is called once per frame
    void Update() {
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
        Debug.Log("Growed?");
        if (growthCount < 2) {
            Debug.Log("Village growth triggered!");
            spriteRenderer.sprite = sprites[growthCount + 1];
            growthCount++;
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
                BlowUp();
                PlayExplosion();
                isDestroyed = true;
                
            }
        }
    }

    private void BlowUp() {
        Vector3 pos = GetComponent<Transform>().position;
        // pos.x += 0.81f;
        // pos.y += 0.48f;
        Instantiate(destroyedVersions[growthCount], pos, Quaternion.identity);
        //pos.y -= 1f;
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

    private void ChangeScene() {
        Debug.Log("invoked woo");
        //Destroy(gameObject);
        gameObject.SetActive(false);
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameEnd");
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
