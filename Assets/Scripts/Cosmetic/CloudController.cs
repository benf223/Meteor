using UnityEngine;

public class CloudController : MonoBehaviour
{
	[HideInInspector] public int direction;

	public Transform tf;
	public float speed;
	public float minSize;

	private Rigidbody2D rb;
	private int timer;
	private readonly float maxSize = 1f;

	private void Start()
	{
		if (tf == null)
			tf = GetComponent<Transform>();

		RandomizeSize();

		rb = GetComponent<Rigidbody2D>();
		rb.AddForce(new Vector2(15 * speed * direction, 0));
	}

	private void RandomizeSize()
	{
		float newSize = Random.Range(minSize, maxSize);
		tf.localScale = new Vector3(newSize, newSize, 1);
		speed *= newSize;
	}
}