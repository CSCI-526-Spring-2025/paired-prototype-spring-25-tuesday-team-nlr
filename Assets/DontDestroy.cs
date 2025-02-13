using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DontDestroy : MonoBehaviour
{
    public static DontDestroy Instance { get; private set; }
    void Start()
    {
       this.gameObject.SetActive(false);
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
