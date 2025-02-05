using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainGameplay : MonoBehaviour
{
    public TMP_Text timerText;
    // Time left before the switch
    public float remainingTime = 90;
    // How llong to show the timer for
    public float timeToDisplay = 2;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("R key was pressed!");
            timeToDisplay = 2;
        }

        remainingTime -= Time.deltaTime;
        timeToDisplay -= Time.deltaTime;

        // Show Timer
        if (timeToDisplay >= 0)
        {
            int minutes = Mathf.FloorToInt(remainingTime / 60);
            int seconds = Mathf.FloorToInt(remainingTime % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        else
        {
            // Hide  timer
            timerText.text = " ";
        }
    }

}
