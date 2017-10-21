using UnityEngine;

public class CloudController : MonoBehaviour
{
	public float speed;

	public float minSize;
	private readonly float maxSize = 1f;

	public Transform tf;

	[HideInInspector]
	public int direction;
	
	private Rigidbody2D rb;
	private int timer;
	
	private void Start()
	{	
		if (tf == null) {
			tf = GetComponent<Transform>();
		}

		//@TODO RANDOMIZE THE TRANSFORM SIZE
		RandomizeSize();

		rb = GetComponent<Rigidbody2D>();
		rb.AddForce(new Vector2((15 * speed) * direction, 0));
		
	}

	private void RandomizeSize() {
		float newSize = Random.Range(minSize, maxSize);
		tf.localScale = new Vector3(newSize, newSize, 1);
		speed *= newSize;
	}
}