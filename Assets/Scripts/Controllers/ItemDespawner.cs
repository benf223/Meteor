using UnityEngine;

public class ItemDespawner : MonoBehaviour
{
	public GameController gameController;

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "ItemBox")
			Destroy(other.gameObject);
	}
}