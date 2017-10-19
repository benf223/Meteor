using UnityEngine;

public class SlowDownMeteoritesController : Powerup
{
	public float slowedGravityScale;

	private MeteoriteSpawnerController spawnerController;

	private new void Start()
	{
		spawnerController = GameObject.FindWithTag("MeteoriteSpawner").GetComponent<MeteoriteSpawnerController>();
		base.Start();
	}

	protected override void ActivatePowerup()
	{
		if (Debug.isDebugBuild)
			Debug.Log("Meteorites slowed down!");
		
		spawnerController.gravityScale = slowedGravityScale;
		
		if (Debug.isDebugBuild)
			Debug.Log(spawnerController.gravityScale);

		GameObject[] meteorites = GameObject.FindGameObjectsWithTag("Meteorite");
		
		if (meteorites != null)
			foreach (GameObject m in meteorites)
				m.GetComponent<Rigidbody2D>().gravityScale = slowedGravityScale;
	}

	protected override void DeactivatePowerup()
	{
		if (Debug.isDebugBuild)
			Debug.Log("Meteorites returned to normal speed");
		
		spawnerController.gravityScale = spawnerController.defaultGravityScale;
		GameObject[] meteorites = GameObject.FindGameObjectsWithTag("Meteorite");
		
		if (meteorites != null)
			foreach (GameObject m in meteorites)
				m.GetComponent<Rigidbody2D>().gravityScale = spawnerController.defaultGravityScale;
		
		Destroy(gameObject);
	}
}