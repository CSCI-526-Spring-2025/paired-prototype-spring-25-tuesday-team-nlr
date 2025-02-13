using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.VersionControl;
using UnityEngine;
using TMPro;

public class WinnerManager : MonoBehaviour
{
    public static WinnerManager Instance { get; private set; }
    public GameObject winnerPanel; 
    public TMP_Text winnerText;
    
    public List<GameObject> left_Soldiers = new List<GameObject>(), 
                            right_Soldiers = new List<GameObject>();


    private void Start()
    {
        left_Soldiers = PlayerManager.Instance.leftPlayerList;
        right_Soldiers = PlayerManager.Instance.rightPlayerList;
    }

    void Update()
    {
        left_Soldiers = PlayerManager.Instance.leftPlayerList;
        right_Soldiers = PlayerManager.Instance.rightPlayerList;
        ShouldEndGame();
    }
    public void RemoveSoldier(String sideTag, GameObject soldier)
    {
        if( SideSwitching.gameStart){
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
    }

    public void ShouldEndGame()
    {
        if (right_Soldiers.Count == 0 || left_Soldiers.Count == 0) {EndGame();}
    }

    public void EndGame()
    {
         if(SideSwitching.gameStart)
        {
            Debug.Log("end game" + left_Soldiers.Count + " " + right_Soldiers.Count);
            String winner = "Player 1 Won!";
            if  (left_Soldiers.Count == right_Soldiers.Count)
            {
                winner = "It's a Tie!";    
            }
            else if (left_Soldiers.Count > right_Soldiers.Count)
            {
                SideSwitching.gameStart = false;
                if (SideSwitching.HasSideSwitched)
                {
                    winner = "Player 2 Won!";
                }
            }
            else
            {
                if (!SideSwitching.HasSideSwitched)
                {
                    winner = "Player 2 Won!";
                }
            }
            winnerPanel.gameObject.SetActive(true);
            winnerText.text = string.Format(winner);
            SideSwitching.gameStart = false;
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
    public void RestartGame()
    {
        winnerPanel.gameObject.SetActive(false);
        left_Soldiers.Clear();
        right_Soldiers.Clear();
        Debug.Log("Winner Manager: Restart Game");
    }

    public void HideUI()
    {
        Debug.Log("HideUI");
        winnerPanel.gameObject.SetActive(false);
    }

}
