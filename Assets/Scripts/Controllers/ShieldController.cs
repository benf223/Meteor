using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : MonoBehaviour
{

    private GameObject shield;
    private float startTimer;
    private float timeSinceStart;
    private int counter;
    private int shieldHealth;

    Color blue;
    Color yellow;
    Color red;

    // Use this for initialization
    void Start()
    {
        shield = GameObject.Find("Shield");

        startTimer = Time.timeSinceLevelLoad;
        timeSinceStart = 0;
        counter = 0;
        shieldHealth = 100;

        blue = new Color(0.0f, 0.95f, 1.0f);
        yellow = new Color(1.0f, 1.0f, 0);
        red = new Color(1.0f, 0.2f, 0.2f);
        shield.GetComponent<Renderer>().material.color = blue;

        InvokeRepeating("CautionOfShield", 5.0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        // destory shield after 10 seconds
        timeSinceStart = Time.timeSinceLevelLoad - startTimer;
        if (timeSinceStart > 10 || shieldHealth == 1)
        {
            Destroy(shield);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Meteorite"))
        {
            shieldHealth -= 33;
            if (shieldHealth == 67)
            {
                shield.GetComponent<Renderer>().material.color = yellow;
            }
            else if (shieldHealth == 34)
            {
                shield.GetComponent<Renderer>().material.color = red;
            }
        }
    }

    public void CautionOfShield()
    {
        Indicator();
        if (timeSinceStart > 8)
        {
            CancelInvoke();
            counter = 0;
            InvokeRepeating("Indicator", 0, 0.25f);
        }
        if (timeSinceStart > 10)
        {
            CancelInvoke();
        }
    }

    public void Indicator()
    {
        if (counter == 0)
        {
            if (timeSinceStart > 8 && shieldHealth == 34)
            {
                Debug.Log("Red " + timeSinceStart);
                shield.GetComponent<Renderer>().material.color = red;
            }
            else if (shieldHealth == 67)
            {
                Debug.Log("Yellow " + timeSinceStart);
                shield.GetComponent<Renderer>().material.color = yellow;
            }
            counter++;
        }
        else if (counter == 1)
        {
            if (shieldHealth == 100)
            {
                Debug.Log("Blue " + timeSinceStart);
                shield.GetComponent<Renderer>().material.color = blue;
            }
            else if (shieldHealth == 67)
            {
                Debug.Log("Red " + timeSinceStart);
                shield.GetComponent<Renderer>().material.color = red;
            }
            counter--;
        }
    }
}
