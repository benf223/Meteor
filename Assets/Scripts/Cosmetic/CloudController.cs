using UnityEngine;

public class CloudController : MonoBehaviour
{
	public int size;

	public float minSize;
	private readonly float maxSize = 1f;

	public Transform tf;

	[HideInInspector]
	public int direction;
	
	private float speed;
	private Rigidbody2D rb;
	private int timer;
	
	private void Start()
	{	
		if (tf == null) {
			tf = GetComponent<Transform>();
		}

		//@TODO RANDOMIZE THE TRANSFORM SIZE
		rb = GetComponent<Rigidbody2D>();
		
		rb.AddForce(new Vector2((40 + size) * direction, 0));
	}
}