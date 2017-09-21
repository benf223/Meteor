using UnityEngine;

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
<<<<<<< HEAD
    private int interval = 1; // Time to update (seconds)
    private float elapsedTime;
    private int secondsToIncreaseDifficulty;

    // used to minus the duration time frames
    private int timeRemoved;
    private float spawnDelayMultiplier;
    private float speedMultiplier;
    private bool meteorSpawnDelayDifficultyUpdated;

    // Use this for initialization
    void Start()
    {
        timeFlowing = false;
        secondsToIncreaseDifficulty = 0;
        timeRemoved = 0;
        spawnDelayMultiplier = 1.0f;
        speedMultiplier = 1.0f;
        meteorSpawnDelayDifficultyUpdated = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeFlowing)
        {
            UpdateTime();
            DifficultyTimeFrame();

            // Updates every second (or based on interval variable)
            if (Time.time >= elapsedTime) {
                elapsedTime += interval;
                UpdateEverySecond();
            }
        }
    }

    // Called Every Second
    private void UpdateEverySecond() {
	    gameCont.AddScore(1);
        secondsToIncreaseDifficulty++; // Used for the difficulty increase interval
    }

    void DifficultyTimeFrame()
    {
        // does 20, 19, 18, 17, 16, 15 all the way to 10 seconds it changes difficulty
        // Note: Default values (20 - timeRemoved), (timeRemoved <= 10)
        if (secondsToIncreaseDifficulty == 20 - timeRemoved)
        {
            if (timeRemoved <= 10)
            {
                timeRemoved++;
            }

            // Modify spawn delay multiplier
            // NOTE THIS CAN CHANGE
            // this decreases from 1 to 0.25 using 0.05 for every difficulty time frame.
            // To further optimize, this section should call a method from the spawner
            // Alvin will be keen to refactor these sections of code after main game is completed
            if (spawnDelayMultiplier >= 0.25f) {
<<<<<<< HEAD:Assets/Scripts/DifficultyManagerController.cs
                spawnDelayMultiplier -= 0.05f;
                Debug.Log("Meteor spawn delay decreased");
=======
                spawnDelayMultiplier -= 0.15f;
>>>>>>> Ben-Test:Assets/Scripts/Controllers/Game Controllers/DifficultyManagerController.cs
            }

            // Modify meteorite speed multiplier
            // NOTE THIS CAN CHANGE
            // this increases from 1.0 to 2.0 using 0.05 for every difficulty time frame.
            if (speedMultiplier <= 2.0f) {
                speedMultiplier += 0.05f;
            }

            secondsToIncreaseDifficulty = 0; // Reset countdown timer for difficulty change
            meteorSpawnDelayDifficultyUpdated = true; // Notifies that difficulty has changed
        }
    }

    // Used only for the MeteoriteSpawnController.
    // Checks if difficulty has been updated, then resets status onced used
    public bool MeteorSpawnDelayDifficultyUpdated() {
        if (meteorSpawnDelayDifficultyUpdated) {
            meteorSpawnDelayDifficultyUpdated = false;
            return true;
        }
	    
=======
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
	void Start()
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
	void Update()
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
		//Debug.Log(seconds);
	}

	void DifficultyTimeFrame()
	{
		// does 20, 19, 18, 17, 16, 15 all the way to 10 seconds it changes difficulty
		// Note: Default values (20 - timeRemoved), (timeRemoved <= 10)
		if (secondsToIncreaseDifficulty == initialDifficultyTime - timeRemoved)
		{
			if (timeRemoved < maxDifficultyTime)
			{
				timeRemoved++;
			}

			// Modify spawn delay multiplier
			// NOTE THIS CAN CHANGE
			// this decreases from 1 to 0.25 using 0.05 for every difficulty time frame.
			// To further optimize, this section should call a method from the spawner
			// Alvin will be keen to refactor these sections of code after main game is completed
			if (spawnDelayMultiplier >= 0.4f)
			{
				spawnDelayMultiplier -= 0.035f;
			}

			// Modify meteorite speed multiplier
			// NOTE THIS CAN CHANGE
			// this increases from 1.0 to 2.0 using 0.05 for every difficulty time frame.
			if (speedMultiplier <= 1.75f)
			{
				speedMultiplier += 0.035f;				
			}

			secondsToIncreaseDifficulty = 0; // Reset countdown timer for difficulty change
			difficultyUpdated = true; // Notifies that difficulty has changed
		}
	}

	// Used only for the MeteoriteSpawnController.
	// Checks if difficulty has been updated, then resets status onced used
	public bool DifficultyUpdated()
	{
		
		if (difficultyUpdated)
		{
			Debug.Log("Difficulty Updated");
			difficultyUpdated = false;
			return true;
		}

>>>>>>> Ben-Test
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