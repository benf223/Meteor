using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillageController : MonoBehaviour {

    public bool isDestroyed;
    public GameObject difficultyManager;
    private DifficultyManagerController difficultyManagerController;
    public Sprite[] sprites;

    private int latestSeconds;
    private int growthCount;
    private SpriteRenderer spriteRenderer;

    public bool godMode;

    // Use this for initialization
	private void Start() {
        // Initialize the difficulty manager script
        if (difficultyManager != null) {
            difficultyManagerController = difficultyManager.GetComponent<DifficultyManagerController>();
        }
        

        //this is what makes it so that the sprite can be changed in run time not via animation, can be swapped
        //to animation later on
        spriteRenderer = GetComponent<Renderer>() as SpriteRenderer;
        
        growthCount = 0;
        UpdateCollider();
        Debug.Log("Village Created Succesfully");
    }

	private void FixedUpdate() {
        // if (difficultyManagerController != null && difficultyManagerController.DifficultyUpdated()) {
        //     IncreaseSize();
        // }
    }

    // Update is called once per frame
	private void Update() {
        
    }
    /**
	 * This method increases the size of the village sprite by .2 lengthwise for the first 20 seconds, and then
	 * .2 in height for the next 50, after this the village will not grow anymore. This can be altered later on 
	 * by simply changing the vector values and the amount of time in the update() method for this script
     * 
     * NOTE: This function is called within the difficulty manager controller to make sure it is called 100% of the time
     * WILL NEED TO FIGURE OUT WHY IT WON'T CALL WHEN IN THE UPDATES 100% OF THE TIME
	 * */
    public void IncreaseSize() {
        if (growthCount < 2) {
            Debug.Log("Village growth triggered!");
            spriteRenderer.sprite = sprites[growthCount + 1];
            UpdateCollider();
        }
        growthCount++;
    }

	private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Meteorite")) {
            if (!godMode) {
                MeteoriteController meteorite = collision.gameObject.GetComponent<MeteoriteController>();
                meteorite.BlowUp();
                isDestroyed = true;

                Destroy(gameObject);
                Debug.Log("Village Destroyed: "+isDestroyed);

                UnityEngine.SceneManagement.SceneManager.LoadScene("GameEnd");
            }

        }
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
