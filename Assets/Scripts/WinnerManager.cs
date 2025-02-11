using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.VersionControl;
using UnityEngine;

public class WinnerManager : MonoBehaviour
{
    public static WinnerManager Instance { get; private set; }
    public List<GameObject> left_Soldiers = new List<GameObject>(), 
                            right_Soldiers = new List<GameObject>();
    public bool hasGameResolved = false;

    private void Start()
    {
        left_Soldiers = PlayerManager.Instance.leftPlayerList;
        right_Soldiers = PlayerManager.Instance.rightPlayerList;
    }

    public void RemoveSoldier(String sideTag, GameObject soldier)
    {
        if (sideTag == "left")
        {
            left_Soldiers.Remove(soldier);
            //Debug.Log("p1: " + p1_Soldiers);
        }
        else if(sideTag == "right")
        {
            right_Soldiers.Remove(soldier);
            //Debug.Log("p2: " + p2_Soldiers);
        }
        ShouldEndGame();
    }

    public void ShouldEndGame()
    {
        if (right_Soldiers.Count == 0 || left_Soldiers.Count == 0) {EndGame();}
    }

    private void EndGame()
    {
        String winner = "n/a";
        if (left_Soldiers.Count == 0)
        {
            if (SideSwitching.HasSideSwitched)
            {
                winner = "P1";
            }
            else
            {
                winner = "P2";
            }
        }else if (right_Soldiers.Count == 0)
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
