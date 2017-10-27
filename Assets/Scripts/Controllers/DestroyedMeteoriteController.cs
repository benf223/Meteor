using UnityEngine;

public class DestroyedMeteoriteController : MonoBehaviour
{
	public float aliveTime = 7.5f;

	// Use this for initialization
	private void Start()
	{
		Invoke("Despawn", aliveTime);
	}

	private void Despawn()
	{
		Destroy(gameObject);
	}
}