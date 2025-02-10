using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TimerUI : MonoBehaviour
{

    public TMP_Text gameTimerText;
    public TMP_Text timerText;

    // Time left before the switch
    public float timerUI = 3;

    // How long before the game ends
    public float gameTime = 45;
    private float gameTimeUI = 45;

    private bool gameStart = false;
    private bool endGame = false;
    // How long to show the timer for
    // Start is called before the first frame update
    public void StartGame()
    {
        gameStart = true;
    }

    // Update is called once per frame
    void Update()
    {


        int min = Mathf.FloorToInt(gameTimeUI / 60);
        int sec = Mathf.FloorToInt(gameTimeUI % 60);
        gameTimerText.text = string.Format("{0:00}:{1:00}", min, sec);
        if (gameStart)
        {
            gameTimeUI -= Time.deltaTime;
            if (SideSwitching.displaytimer)
            {

                // switch timer
                timerUI -= Time.deltaTime;
                // Show Timer
                if (timerUI >= 0)
                {
                    int minutes = Mathf.FloorToInt(timerUI / 60);
                    int seconds = Mathf.FloorToInt(timerUI % 60);
                    timerText.text = string.Format("Switching sides in {0:00}:{1:00}", minutes, seconds);
                }
                else
                {
                    // Hide  timer
                    timerText.text = " ";
                    SideSwitching.displaytimer = false;
                    timerUI = 3;
                }
            }
            if (gameTimeUI <= 0)
            {
                gameStart = false;
                endGame = true;
            }
        }

    }
    public void RestartGame()
    {
        gameStart = false;
        gameTimeUI = gameTime;
        endGame = false;
    }
    public bool GetGameStatus()
    {
        return endGame;
    }
}
