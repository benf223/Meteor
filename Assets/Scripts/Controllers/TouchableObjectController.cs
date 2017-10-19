using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchableObjectController : MonoBehaviour {

    protected GameObject difficultyManager;
    protected DifficultyManagerController difficultyManagerController;
    public Rigidbody2D rb;

    public int touchCount = 1;

    public string customTag;

    public PhysicsMaterial2D lowBounce;


    // FOR SPRITES
    public SpriteRenderer spriteRenderer;
    public Variations[] spriteArray;
    private int spriteIndex;
    [System.Serializable]
    public class Variations {
        public Sprite[] sprites = new Sprite[2];
    }



    [HideInInspector]
    public bool touching; // State in which meteorite is in process of flick
    private bool touched; // State in which meteorite HAS BEEN touched
    private GameObject touchObject;

    // Use this for initialization
    protected void Start() {
        //touchCount = 1;
        touchObject = null;
        touched = false;
        touching = false;
        SelectRandomSprite();
        difficultyManager = GameObject.Find("DifficultyManager");

        if (difficultyManager != null) {
            difficultyManagerController = difficultyManager.GetComponent<DifficultyManagerController>();
        }

        //InitializeSpeed();
    }

   // Update is called once per frame
    protected void Update() {

        if (touching) {
            if (touchObject == null) {
                touched = true;
                touching = false;
            }
        }
    }


    public void BlowUp() {
        
        Destroy(gameObject);
    }


    public void SetTouched(GameObject touchObject) {
        touching = true;
        this.touchObject = touchObject;
        Debug.Log(touchCount);
        touchCount--;

        Collider2D cd = GetComponent<Collider2D>();
        cd.sharedMaterial = lowBounce;
        if (spriteArray.Length > 0 && touchCount <= 0) {
            spriteRenderer.sprite = spriteArray[spriteIndex].sprites[1];
        }
    }

    public bool IsTouching() {
        return touching;
    }

    public bool Touched() {
        return touched;
    }

    public void SetTouched(bool touched) {
        this.touched = touched;
    }

    private void SelectRandomSprite() {
        if (spriteArray.Length > 0) {
            int size = spriteArray.Length;
            spriteIndex = Random.Range(0, size);
            spriteRenderer.sprite = spriteArray[spriteIndex].sprites[0];
        }

    }
}
