using UnityEngine;

public class TouchableObjectController : MonoBehaviour
{
	[HideInInspector] public bool touching; 	// State in which meteorite is in process of flick
	
	public Rigidbody2D rb;
	public int touchCount = 1;
	public string customTag;
	public PhysicsMaterial2D lowBounce;
	public SpriteRenderer spriteRenderer;		// FOR SPRITES
	public Variations[] spriteArray;
	
	protected GameObject difficultyManager;
	protected DifficultyManagerController difficultyManagerController;
	
	private GameObject touchObject;
	private int spriteIndex;
	private bool touched; 						// State in which meteorite HAS BEEN touched
	

	// Use this for initialization
	protected void Start()
	{
		touchObject = null;
		touched = false;
		touching = false;
		SelectRandomSprite();
		difficultyManager = GameObject.Find("DifficultyManager");

		if (difficultyManager != null)
			difficultyManagerController = difficultyManager.GetComponent<DifficultyManagerController>();
	}

	// Update is called once per frame
	protected void Update()
	{
		if (touching)
			if (touchObject == null)
			{
				touched = true;
				touching = false;
			}
	}

	public void BlowUp()
	{
		Destroy(gameObject);
	}

	public void SetTouched(GameObject touchObject)
	{
		touching = true;
		this.touchObject = touchObject;
		
		if (Debug.isDebugBuild)
			Debug.Log(touchCount);
		
		touchCount--;

		Collider2D cd = GetComponent<Collider2D>();
		cd.sharedMaterial = lowBounce;
		
		if (spriteArray.Length > 0 && touchCount <= 0)
		{
			spriteRenderer.sprite = spriteArray[spriteIndex].sprites[1];
		}
	}

	public bool IsTouching()
	{
		return touching;
	}

	public bool Touched()
	{
		return touched;
	}

	public void SetTouched(bool touched)
	{
		this.touched = touched;
	}

	private void SelectRandomSprite()
	{
		if (spriteArray.Length > 0)
		{
			int size = spriteArray.Length;
			spriteIndex = Random.Range(0, size);
			spriteRenderer.sprite = spriteArray[spriteIndex].sprites[0];
		}
	}
	
	[System.Serializable]
	public class Variations
	{
		public Sprite[] sprites = new Sprite[2];
	}
}