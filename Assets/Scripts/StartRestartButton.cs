using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class StartRestartButton : MonoBehaviour
{
    public TMP_Text ButtonText;
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
            Debug.Log("Starting");
        }
        else
        {
            RestartGame();
            isStart = true;
            ButtonText.text = "Start";
            Debug.Log("Restart");
        }
    }
      public void RestartGame()
    {

    }

    public void StartGame()
    {

    }
}
