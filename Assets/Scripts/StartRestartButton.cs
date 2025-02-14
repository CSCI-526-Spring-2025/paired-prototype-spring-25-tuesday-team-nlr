using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class StartRestartButton : MonoBehaviour
{
    public TMP_Text ButtonText;
    public GameObject winnerPanel; 
    public TimerUI timer;
    private bool isStart = true;
    private string endText = "Restart";

    void Start()
    {
        winnerPanel.gameObject.SetActive(false);
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
        SceneManager.LoadScene(0);
        isStart = true;
        timer.RestartGame();
        SideSwitching.gameStart = false;
        SideSwitching.hasSideSwitched = false;
        ButtonText.text = "Start";
        Debug.Log("Restart");
        WinnerManager.Instance.HideUI();
    }

    public void StartGame()
    {
        Debug.Log("Starting");
        timer.StartGame();
        SideSwitching.gameStart = true;
        WinnerManager.Instance.HideUI();
    }
}
