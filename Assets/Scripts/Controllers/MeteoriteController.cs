using UnityEngine;

public class MeteoriteController : TouchableObjectController
{

	public AudioClip audio;
	public AudioClip water;
	public GameObject explosion;
	

	private void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.CompareTag ("Wall") && transform.position.y < 5) {
			AudioSource.PlayClipAtPoint (audio, transform.position); 
		}
	}

	public void BlowUp()
	{	
		
		base.BlowUp();
	}

	public void SetGravityScale(float gs)
    {
        rb.gravityScale = gs;
    }
}


