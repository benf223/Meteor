using UnityEngine;

public class StarController : MonoBehaviour
{
	private bool twinkling;
	private int twinkleTimes;
	private int twinkledTimes;

	[HideInInspector] public float scale;
	
	void Start()
	{
		twinkling = false;
		twinkleTimes = Random.Range(2, 5);
		twinkledTimes = 0;
		transform.localScale = new Vector3(0, 0, 0);
	}

	void Update()
	{
		if (twinkling)
		{
			UnTwinkle();
		}
		else
		{
			Twinkle();
		}
		
		twinkling = !twinkling;
	}

	private void Twinkle()
	{
		if (twinkledTimes < twinkleTimes)
		{
			twinkling = true;

			transform.localScale = new Vector3(1 * scale, 1 * scale, 0);

			++twinkledTimes;
			
			return;
		}
		
		Destroy(gameObject);
	}

	private void UnTwinkle()
	{
		transform.localScale = new Vector3(0, 0, 0);
		
		if (twinkledTimes == twinkleTimes)
			Destroy(gameObject);
	}

	private void OnDestroy()
	{
		GameObject.Find("HighscoreManager").GetComponent<HighscoreManager>().StarDespawned();
	}
}