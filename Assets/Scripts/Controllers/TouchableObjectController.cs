using UnityEngine;

public class TouchableObjectController : MonoBehaviour
{
	[HideInInspector] public bool touching; 		// State in which meteorite is in process of flick
	
	protected GameObject difficultyManager;
	protected DifficultyManagerController difficultyManagerController;
	
	public Rigidbody2D rb;
	public PhysicsMaterial2D lowBounce;
	public GameObject destroyedVersion;
	public SpriteRenderer spriteRenderer;
	public Variations[] spriteArray;
	public int touchCount = 1;
	public string customTag;
	
	private GameObject touchObject;
	private int spriteIndex;
	private bool touched;							 // State in which meteorite HAS BEEN touched
	
	[System.Serializable]
	public class Variations
	{
		public Sprite[] sprites = new Sprite[2];
	}

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

		if (rb == null)
			rb = GetComponent<Rigidbody2D>();
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
		if (destroyedVersion != null)
			Instantiate(destroyedVersion, rb.position, Quaternion.identity);
		
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
			spriteRenderer.sprite = spriteArray[spriteIndex].sprites[1];
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
}