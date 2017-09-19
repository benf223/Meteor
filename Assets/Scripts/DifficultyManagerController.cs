using UnityEngine;

public class DifficultyManagerController : MonoBehaviour
{
    private float startTimer;
    private float countTime;
	public GameController gameCont;

    // condition to keep the time continuing
    public bool timeFlowing;

    // time
    //private int hours;
    private int minutes;
    private int seconds;

    private int interval = 2; // Time to update (seconds)
    private float elapsedTime = 0;

    private int secondsToIncreaseDifficulty;

    // used to minus the duration time frames
    private float timeRemoved;

    private float spawnDelayMultiplier;
    private float speedMultiplier;

    private bool meteorSpawnDelayDifficultyUpdated;

    // Use this for initialization
    void Start()
    {
        timeFlowing = false;
        secondsToIncreaseDifficulty = 0;
        timeRemoved = 0;
        spawnDelayMultiplier = 0.75f;
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
		gameCont.AddScore (1);
        secondsToIncreaseDifficulty++; // Used for the difficulty increase interval
        // Debug.Log("Reset seconds = " +secondsToIncreaseDifficulty);
    }

    void DifficultyTimeFrame()
    {
        // does 10 to 5 seconds, every 1 it changes difficulty
        // Note: Default values (20 - timeRemoved), (timeRemoved <= 10)
        if (secondsToIncreaseDifficulty > (10 - timeRemoved))
        {
            if (timeRemoved < 5)
            {
                timeRemoved += 1;
            }

          /* Modify spawn delay multiplier
             NOTE THIS CAN CHANGE
             we think 0.75 is the optimal range for each meteorite to spawn
             this decreases from 1 to 0.75 using 0.025 for every difficulty time frame.
             To further optimize, this section should call a method from the spawner
             Alvin will be keen to refactor these sections of code after main game is completed */
            if (spawnDelayMultiplier >= 0.40f) {
                spawnDelayMultiplier -= 0.035f;
                Debug.Log("Meteor spawn delay decreased: "+spawnDelayMultiplier);
            }

            /* Modify meteorite speed multiplier
               NOTE THIS CAN CHANGE
               this increases from 1.0 to 1.75 using 0.025 for every difficulty time frame. */
            if (speedMultiplier <= 1.75f) {
                speedMultiplier += 0.035f;
                Debug.Log("Meteor speed increased");
            }

            secondsToIncreaseDifficulty = 0; // Reset countdown timer for difficulty change
            Debug.Log("Difficulty Time Frame Activated");
            meteorSpawnDelayDifficultyUpdated = true; // Notifies that difficulty has changed

        }
    }

    // Used only for the MeteoriteSpawnController.
    // Checks if difficulty has been updated, then resets status onced used
    public bool MeteorSpawnDelayDifficultyUpdated() {
        if (meteorSpawnDelayDifficultyUpdated) {
            meteorSpawnDelayDifficultyUpdated = false;
            return true;
        } else {
            return false;
        }
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
        startTimer = Time.time;
    }

    public void UpdateTime()
    {
        countTime = Time.time - startTimer;

        //hours = ((int)countTime / 360);
        minutes = ((int)countTime / 60);
        seconds = ((int)countTime % 60);
    }

    public void PauseTimer()
    {
        timeFlowing = false;
    }

    public void ResumeTimer()
    {
        timeFlowing = true;
        Time.timeScale = 1;
    }

    public void ResetTimer()
    {
        timeFlowing = false;
        Time.timeScale = 0;
    }

	public int GetSeconds() {
		return seconds;
	}
}
