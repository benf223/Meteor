using UnityEngine;

public class MultipleTouchesPowerupController : Powerup
{
	public int touchCount;
	
	private MeteoriteSpawnerController spawnerController;
	private GameObject test;

	private new void Start()
	{
		spawnerController = GameObject.FindWithTag("MeteoriteSpawner").GetComponent<MeteoriteSpawnerController>();
		base.Start();
	}

	protected override void ActivatePowerup()
	{
		if (Debug.isDebugBuild)
			Debug.Log(powerupName + " is now Activated");
		
		spawnerController.touchCount = touchCount;
	}

	protected override void DeactivatePowerup()
	{
		if (Debug.isDebugBuild)
			Debug.Log(powerupName + " is now Deactivated");
		
		spawnerController.touchCount = spawnerController.defaultTouchCount;
		Destroy(gameObject);
	}
}