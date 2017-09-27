using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float multiplier;
    
	// Update is called once per frame
	private void Update()
	{
		Rigidbody2D rb = GetComponent<Rigidbody2D>();
		
		rb.MoveRotation(rb.rotation + 2 * multiplier);
	}
}