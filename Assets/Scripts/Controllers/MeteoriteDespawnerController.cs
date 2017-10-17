using UnityEngine;

public class MeteoriteDespawnerController : MonoBehaviour
{
	public GameController gameCont;
	public AudioClip water;
	public int amountDespawned { get; private set; }
	public bool despawnItemBoxes = true;

	private void OnTriggerEnter2D(Collider2D other)
	{
		gameObject.GetComponent<AudioSource>().Play();
		if (other.gameObject.tag.Equals("Meteorite"))
		{
			Destroy(other.gameObject);

			if (gameCont != null)
			{
				gameCont.AddScore(2);
			}
		}

		if (despawnItemBoxes && other.gameObject.CompareTag("ItemBox"))
		{
			Destroy(other.gameObject);
		}
	}
}