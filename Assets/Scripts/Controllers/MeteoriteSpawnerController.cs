using UnityEngine;

public class MeteoriteSpawnerController : MonoBehaviour {
    public int amountSpawned { get; private set; }
    public GameObject meteorite;
    public GameObject difficultyManager;

    private Collider2D cd;
    private DifficultyManagerController difficultyManagerController;

    public bool spawningEnabled = true;

    // Breath time for when to start the spawning of meteorites
    private float startSpawnTime = 0.75f;

    // Spawn delay between meteorites
    private float timeBetweenSpawn;
    public float startingTimeBetweenSpawn;

    // Minimum and maximum spawn force
    public float minSpawnForce;

    public float maxSpawnForce;

    public float fastSpawnForceMultiplier;

    // Testing tthe time for first spawn
    private float startTime;

    private float timeFirstSpawn = -1;

    // Use this for initialization
    private void Start() {
        timeBetweenSpawn = startingTimeBetweenSpawn;
        startTime = Time.timeSinceLevelLoad;

        if (Debug.isDebugBuild) {
            Debug.Log("Spawn Rate: " + timeBetweenSpawn);
        }

        cd = GetComponent<BoxCollider2D>();

        if (difficultyManager != null) {
            difficultyManagerController = difficultyManager.GetComponent<DifficultyManagerController>();
        }
    }

    // Update is called once per frame
    private void Update() {
        // If difficulty has been updated, then update.
        if (difficultyManagerController != null && difficultyManagerController.DifficultyUpdated()) {
            // NOTE: Set time for spawn delay
            timeBetweenSpawn = startingTimeBetweenSpawn * difficultyManagerController.GetMeteoriteSpawnDelayMultiplier();

            if (Debug.isDebugBuild) {
                Debug.Log("Spawn Rate: " + timeBetweenSpawn);
            }
        }
    }

    private void FixedUpdate() {
        /**
		 * Start spawning meteorites when breathing time reached
		 * and then set the delay for spawn times between meteorites
		 */
        if (Time.timeSinceLevelLoad >= startSpawnTime) {
            SpawnMeteorites();
            startSpawnTime = Time.timeSinceLevelLoad + timeBetweenSpawn;

            if (Debug.isDebugBuild) {
                /**
				 * For Testing
				 */
                if (timeFirstSpawn == -1) {
                    timeFirstSpawn = Time.timeSinceLevelLoad;
                    Debug.Log("Delay for first spawn: " + (timeFirstSpawn - startTime));
                }
            }
        }
    }

    /**
	 * Function to controll the spawning of meteorites
	 */
    private void SpawnMeteorites() {
        // Gets the bounding box of the box collider
        Bounds spawnBounds = cd.bounds;

        Vector3 min = spawnBounds.min; // Get the minimum values
        Vector3 max = spawnBounds.max; // Get the maximum values

        // Randomize a position within the spawn area
        float x = Random.Range(min.x, max.x);
        float y = Random.Range(min.y, max.y);

        // Instantiate the randomized location
        Vector2 spawnLocation = new Vector3(x, y, 0);

        // Create the object in the random position
        GameObject spawned = Instantiate(meteorite, spawnLocation, Quaternion.identity);
        GameObject village = GameObject.Find("Village");

        float chance = Random.Range(0.0f, 1.0f);

        // This will change to call from the difficulty manager
        float chanceToAimAtVillage = difficultyManagerController.GetMeteoriteSpawnDirectionMultiplier();

        // Debug.Log("Chance to Aim at Village: " + chanceToAimAtVillage);
        // Debug.Log("Actual Chance" + chance);

        if (chance > chanceToAimAtVillage) {
            //            AddRandomForce(spawned);
            AddForceTowardsWall(spawned);
        }
        else {
            AddForceTowardsVillage(spawned, village);
        }

    }

    private void AddForceTowardsVillage(GameObject spawned, GameObject village) {
        Rigidbody2D rb = spawned.GetComponent<Rigidbody2D>();
        Color myColor = new Color(1f, 0.3f, 0.0f); 

        SpriteRenderer meteoriteColor = spawned.GetComponent<SpriteRenderer>();
        meteoriteColor.color = myColor;
        // meteoriteColor.r = 244;
        // meteoriteColor.g = 152;
        // meteoriteColor.b = 66;
        Vector2 villagePos = village.GetComponent<Transform>().position;

        rb.AddForce((villagePos - rb.position).normalized * (GetRandomForce()*fastSpawnForceMultiplier));
        rb.AddTorque(-50.0f); // Make it spin!
    }

    private void AddForceTowardsWall(GameObject spawned) {
        Rigidbody2D rb = spawned.GetComponent<Rigidbody2D>();
        GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");

        int targetIndex = Random.Range(0, walls.Length - 1);
        Vector2 targetLocation = GenerateRandomLocation(walls[targetIndex]);

        //.normalized keeps direction, but length of 1.
        rb.AddForce((targetLocation - rb.position).normalized * GetRandomForce());
        rb.AddTorque(-25.0f); // Make it spin!
    }

    public Vector3 GenerateRandomLocation(GameObject target) {
        Bounds bounds = target.GetComponent<Collider2D>().bounds;
        Vector3 min = bounds.min;
        Vector3 max = bounds.max;

        float x = Random.Range(min.x, max.x);
   
        float   y = Random.Range(min.y, cd.bounds.max.y);

        return new Vector3(x, y, 0);
    }

    /**
     * This function is now obselete as the meteorites will instead target a random spot
     * in the walls.
     */
    private void AddRandomForce(GameObject spawned) {
        Rigidbody2D rb = spawned.GetComponent<Rigidbody2D>();

        // Randomize between spawning to the left, or the right
        // 0 = right, 180 = left
        float angle;
        int randomNum = Random.Range(0, 2);

        if (randomNum == 0) {
            angle = 0;
        }
        else {
            angle = 180;
        }

        // Calculate the force to add
        float addedForce = Random.Range(minSpawnForce, maxSpawnForce);

        // Calculates the direction using the angle
        // TBH, I have no idea how this actually works.
        Vector3 dir = Quaternion.AngleAxis(angle, Vector3.up) * Vector3.right;

        // Finally, add the force to the direction.
        rb.AddForce(dir * addedForce);

        rb.AddTorque(-25.0f); // Make it spin!
    }

    private float GetRandomForce() {
        return Random.Range(minSpawnForce, maxSpawnForce) * difficultyManagerController.GetMeteoriteSpeedMultiplier();
    }
}