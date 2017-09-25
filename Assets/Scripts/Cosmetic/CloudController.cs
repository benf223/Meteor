using UnityEngine;

public class CloudController : MonoBehaviour
{
	public int size;

	[HideInInspector]
	public int direction;
	
	private float speed;
	private Rigidbody2D rb;
	private int timer;
	
	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		
		rb.AddForce(new Vector2((40 + size) * direction, 0));
	}
}