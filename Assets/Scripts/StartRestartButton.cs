using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class StartRestartButton : MonoBehaviour
{
    public TMP_Text ButtonText;
    public TimerUI timer;
    private bool isStart = true;
    private string endText = "Restart";

    void Start()
    {
        WinnerManager.Instance.HideUI();
    }
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

    }
    
    public void RestartGame()
    {
        Debug.Log("RestartGame");
        WinnerManager.Instance.HideUI();
        SceneManager.LoadScene(0);
        isStart = true;
        timer.RestartGame();
        SideSwitching.gameStart = false;
        SideSwitching.hasSideSwitched = false;
        ButtonText.text = "Start";
    }

    public void StartGame()
    {
        timer.StartGame();
        SideSwitching.gameStart = true;
    }
}
