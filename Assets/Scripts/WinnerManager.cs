using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.VersionControl;
using UnityEngine;

public class WinnerManager : MonoBehaviour
{
    public static WinnerManager Instance { get; private set; }
    public int p1_Soldiers=4, p2_Soldiers=4;
    public bool hasGameResolved = false;

    public void DecreaseSoldiers(String sideTag)
    {
        if (sideTag == "left")
        {
            p1_Soldiers--;
            //Debug.Log("p1: " + p1_Soldiers);
        }
        else if(sideTag == "right")
        {
            p2_Soldiers--;
            //Debug.Log("p2: " + p2_Soldiers);
        }
        ShouldEndGame();
    }

    public void ShouldEndGame()
    {
        if (p1_Soldiers == 0 || p2_Soldiers == 0) {EndGame();}
    }

    private void EndGame()
    {
        String winner = "n/a";
        if (p1_Soldiers == 0)
        {
            if (SideSwitching.HasSideSwitched)
            {
                winner = "P1";
            }
            else
            {
                winner = "P2";
            }
        }else if (p2_Soldiers == 0)
        {
            if (SideSwitching.HasSideSwitched)
            {
                winner = "P2";
            }
            else
            {
                winner = "P1";
            }
        }
        if (!hasGameResolved)
        {
            EditorUtility.DisplayDialog("Congratulations!", winner + " wins!", "OK");
            hasGameResolved = true;
        }
    }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
