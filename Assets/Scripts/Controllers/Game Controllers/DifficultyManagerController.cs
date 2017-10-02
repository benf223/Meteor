using UnityEngine;

public class DifficultyManagerController : MonoBehaviour
{
	// condition to keep the time continuing
	public bool timeFlowing;

	public GameController gameCont;

	// time
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
    private float directionChange;
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
        directionChange = 0.4f;

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
	}

	private void DifficultyTimeFrame()
	{
		// does 20, 19, 18, 17, 16, 15 all the way to 10 seconds it changes difficulty
		// Note: Default values (20 - timeRemoved), (timeRemoved <= 10)
		if (secondsToIncreaseDifficulty == initialDifficultyTime - timeRemoved)
		{
			if (timeRemoved < maxDifficultyTime)
			{
				timeRemoved++;
			}

			// starts at 0.75, decreases every .035 and maxs at 0.4 (does it 10 times)
			if (spawnDelayMultiplier >= 0.4f)
			{
				spawnDelayMultiplier -= 0.035f;
			}

			// starts at 1.00, increases every .035 and maxs at 1.75 (does it 21-22 times)
			if (speedMultiplier <= 1.75f)
			{
				speedMultiplier += 0.035f;				
			}

            // starts at 0.40, increases every .025 and maxs at 0.80 (does it 20 times)
            if (directionChange <= 0.80f)
            {
                directionChange += .025f;
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
			if (Debug.isDebugBuild)
			{
				Debug.Log("Difficulty Updated");
			}
			
			difficultyUpdated = false;
			return true;
		}

		return false;
	}

	public float GetMeteoriteSpawnDirectionMultiplier() {

		return directionChange;
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