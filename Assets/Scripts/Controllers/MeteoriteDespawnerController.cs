using UnityEngine;

public class MeteoriteDespawnerController : MonoBehaviour
{
	public GameController gameCont;
	public int amountDespawned { get; private set; }

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag.Equals("Meteorite") || other.gameObject.tag.Equals("PowerUp"))
		{
			Destroy(other.gameObject);
			
			if (gameCont != null)
			{
				gameCont.AddScore(2);
			}
		}
	}
}