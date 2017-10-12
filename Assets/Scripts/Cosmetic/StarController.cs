using UnityEngine;

public class StarController : MonoBehaviour
{
	private int twinkleToggle;
	private int twinkleTimes;
	private int twinkledTimes;

	[HideInInspector] public float scale;
	
	void Start()
	{
		twinkleToggle = 0;
		twinkleTimes = Random.Range(2, 5);
		twinkledTimes = 0;
		transform.localScale = new Vector3(0, 0, 0);
	}

	void Update()
	{
		if (twinkleToggle == 1)
		{
			UnTwinkle();
		}
		else if (twinkleToggle == 0)
		{
			Twinkle();
		}
		else if (twinkleToggle == 5)
		{
			twinkleToggle = 0;
			return;
		}

		++twinkleToggle;
	}

	private void Twinkle()
	{
		if (twinkledTimes < twinkleTimes)
		{
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