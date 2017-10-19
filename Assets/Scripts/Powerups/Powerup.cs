using UnityEngine;
using UnityEngine.UI;

public abstract class Powerup : MonoBehaviour
{
	public float duration; 			// Duration of power up
	public string powerupName; 		// Name of powerup 
	
	protected float startTime; 		// Just the start time. Not to be modifed

	private GameObject sliderObject;
	private Slider slider;
	private Text notifyText;

	protected void Start()
	{
		sliderObject = GameObject.Find("TimeSlider");
		slider = sliderObject.GetComponent<Slider>();
		slider.value = 0f;
		slider.maxValue = duration;
		sliderObject.transform.position = new Vector3(0, 0, 0);
		
		notifyText = GameObject.Find("Powerup Notification").GetComponent<Text>();
		notifyText.text = powerupName + " Activated.";
		notifyText.fontSize = 100;

		// Sets the start time for the duration of the power up
		startTime = Time.timeSinceLevelLoad;
		ActivatePowerup();
	}

	protected void Update()
	{
		UpdateVisibles();

		// Once duration of powerup has been reached, reset all stats and deactivate (destroy) the powerup
		if (Time.timeSinceLevelLoad - startTime >= duration)
		{
			DeactivatePowerup();
			DeactivateSlider();
			Destroy(gameObject);
		}
	}

	protected void UpdateVisibles()
	{
		if (Time.timeSinceLevelLoad - startTime >= 2)
		{
			notifyText.fontSize = 1;
			notifyText.text = "";
		}
		
		slider.value = startTime + duration - Time.timeSinceLevelLoad;
	}

	protected void DeactivateSlider()
	{
		sliderObject.transform.position = new Vector3(0, -100, 0);
	}

	/**
	 * Values to change when power up is activated
	 */
	protected abstract void ActivatePowerup();

	/**
	 * Revert values back to default!
	 */
	protected abstract void DeactivatePowerup();
}