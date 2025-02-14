using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{

    public GameObject powerUpPrefab; 
    public float minY = -3f, maxY = 0f; 
    public float minX = -5f, maxX = 4f;
    public float spawnInterval = 10f;
    public bool setFlag = true;
    void Start()
    {
        
    }

    void SpawnPowerUp()
    {
        if (powerUpPrefab == null) return;
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY); 
        Vector3 spawnPos = new Vector3(randomX, randomY, 0); 

        Instantiate(powerUpPrefab, spawnPos, Quaternion.identity); 
    }
    void Update()
    {
        if (SideSwitching.gameStart && setFlag)
        {
            setFlag = false;
            InvokeRepeating(nameof(SpawnPowerUp), spawnInterval, spawnInterval);
        }
        if (!SideSwitching.gameStart)
        {
            CancelInvoke(nameof(SpawnPowerUp));
            setFlag = true;
        }
    }
}