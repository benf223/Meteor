using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
	private Text text;
	
	// Use this for initialization
	void Start()
	{
		text = GetComponent<Text>();
                          		text.fontSize = 2;
	}

	// Update is called once per frame
	void Update()
	{
		if (text.fontSize != 30)
			text.fontSize = text.fontSize + 1;
	}
}