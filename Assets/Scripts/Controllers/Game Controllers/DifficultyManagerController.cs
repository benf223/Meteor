using UnityEngine;
using UnityEngine.Assertions;

public class DifficultyManagerController : MonoBehaviour
{
	// condition to keep the time continuing
	public bool timeFlowing;

	public GameController gameCont;

	// time
	// private int hours;

	private int minutes;
	private int seconds;
	private float startTimer;
	private float countTime;
	private int interval = 1; // Time to update (seconds)
	private float elapsedTime = 0;
	private int secondsToIncreaseDifficulty;

	// used to minus the duration time frames
	private int timeRemoved;

	private float spawnDelayMultiplier;
	private float speedMultiplier;
	private bool difficultyUpdated;

	public float initialDifficultyTime;
	public float maxDifficultyTime;	

	// Use this for initialization
	private void Start()
	{
		minutes = 0;
		seconds = 0;
		elapsedTime = 0f;
		
		timeFlowing = false;
		secondsToIncreaseDifficulty = 0;
		timeRemoved = 0;
		spawnDelayMultiplier = 0.75f;
		speedMultiplier = 1.0f;
		difficultyUpdated = false;
	}

	// Update is called once per frame
	private void Update()
	{
		if (timeFlowing)
		{
			UpdateTime();
			DifficultyTimeFrame();
			// Updates every second (or based on interval variable)
			if (Time.timeSinceLevelLoad >= elapsedTime)
			{
				elapsedTime += interval;
				UpdateEverySecond();
			}
		}
	}

	// Called Every Second
	private void UpdateEverySecond()
	{
		gameCont.AddScore(1);
		secondsToIncreaseDifficulty++; // Used for the difficulty increase interval
		Debug.Log("Seconds: "+seconds);
	}

	private void DifficultyTimeFrame()
	{
		// does 20, 19, 18, 17, 16, 15 all the way to 10 seconds it changes difficulty
		// Note: Default values (20 - timeRemoved), (timeRemoved <= 10)
		if (secondsToIncreaseDifficulty == initialDifficultyTime - timeRemoved)
		{
            Debug.Log("Difficulty Increase activated");
			if (timeRemoved < maxDifficultyTime)
			{
				timeRemoved++;
			}

            /*  
             *  The Spawn multipler determines how much time is seperated for each meteorite to spawn.
             *  The multipler starts at 0.75f and decreases 0.035f everytime this method is called.
             *  The values will keep changing until it reaches 0.40f.
             */
            if (spawnDelayMultiplier >= 0.4f)
			{
                Assert.AreEqual(true, spawnDelayMultiplier >= 0.4f);
                Debug.Log("Spawn Multipler for each meteorite: " + spawnDelayMultiplier);
                spawnDelayMultiplier -= 0.035f;
            }

            /*
             *  The Speed of meteorites will be determined by this condition.
             *  The initial speed of the meteorites will start from x1 speed.
             *  Each Time this method is called the meteorites speed will increase by 0.035f.
             *  The maximum speed the meteorites will go is x1.75. 
             */
            if (speedMultiplier <= 1.75f)
			{
                Assert.AreEqual(true, speedMultiplier <= 1.75f);
                Debug.Log("Speed Multipler for each meteorite: " + speedMultiplier);
                speedMultiplier += 0.035f;				
			}

			secondsToIncreaseDifficulty = 0; // Reset countdown timer for difficulty change
			difficultyUpdated = true; // Notifies that difficulty has changed

			// Calling this in this object, because it sometimes won't call in the other
			GameObject.Find("Village").GetComponent<VillageController>().IncreaseSize();
		}
	}

	// Checks if difficulty has been updated, then resets status onced used
	public bool DifficultyUpdated()
	{
		
		if (difficultyUpdated)
		{
			Debug.Log("Difficulty Updated");
			difficultyUpdated = false;
			return true;
		}

		return false;
	}


	public float GetMeteoriteSpawnDelayMultiplier()
	{
		return spawnDelayMultiplier;
	}


	public float GetMeteoriteSpeedMultiplier()
	{
		return speedMultiplier;
	}

	public void StartTimer()
	{
		timeFlowing = true;
		startTimer = Time.timeSinceLevelLoad;
	}

	public void UpdateTime()
	{
		countTime = Time.timeSinceLevelLoad - startTimer;

		// hours = (int) countTime / 360;
		minutes = (int) countTime / 60;
		seconds = (int) countTime % 60;
	}

	public void PauseTimer()
	{
		timeFlowing = false;
	}

	public void ResumeTimer()
	{
		timeFlowing = true;
		startTimer = Time.timeSinceLevelLoad - countTime;
	}

	public void ResetTimer()
	{
		timeFlowing = false;
		countTime = 0;
	}

	public int GetSeconds()
	{
		return seconds;
	}
}