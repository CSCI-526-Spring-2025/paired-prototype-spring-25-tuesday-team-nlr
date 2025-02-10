using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class StartRestartButton : MonoBehaviour
{
    public TMP_Text ButtonText;
    public TimerUI timer;
    private bool isStart = true;
    private string endText = "Restart";
    // Start is called before the first frame update
    public void OnClick()
    {
        if (isStart)
        {
            ButtonText.text = endText;
            isStart = false;
            StartGame();
        }
        else
        {
            RestartGame();
        }
    }

    void Update()
    {
        if (timer.GetGameStatus())
        {
            RestartGame();
        }
    }
    public void RestartGame()
    {
        isStart = true;
        ButtonText.text = "Start";
        Debug.Log("Restart");
        timer.RestartGame();
        SideSwitching.gameStart = false;
    }

    public void StartGame()
    {
        Debug.Log("Starting");
        timer.StartGame();
        SideSwitching.gameStart = true;
    }
}
