using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MainButton : MonoBehaviour
{

    public TMP_Text ButtonText;
    private bool isStart = true;
    // Start is called before the first frame update
    public void OnClick()
    {
        if (isStart)
        {
            ButtonText.text = "Restart";
            isStart = false;
        }
        else
        {
            RestartGame();
        }
    }
    public void RestartGame()
    {

    }
}
