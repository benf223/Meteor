using UnityEngine;

public class CloudController : MonoBehaviour
{
	[HideInInspector]
	public int direction;
	
	public int size;
	
	private Rigidbody2D rb;
	private float speed;
	private int timer;
	
	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		
		rb.AddForce(new Vector2((40 + size) * direction, 0));
	}
}