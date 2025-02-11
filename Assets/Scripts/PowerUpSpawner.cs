using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{

    public GameObject powerUpPrefab; 
    public float minY = -3f, maxY = 3f; 
    public float minX = -5f, maxX = 4f;
    public float spawnInterval = 10f; 

    void Start()
    {
        InvokeRepeating(nameof(SpawnPowerUp), spawnInterval, spawnInterval);
    }

    void SpawnPowerUp()
    {
        if (powerUpPrefab == null) return;
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY); // Pick a random Y position
        Vector3 spawnPos = new Vector3(randomX, randomY, 0); 

        Instantiate(powerUpPrefab, spawnPos, Quaternion.identity); // Spawn the power-up
    }
    void Update()
    {
        
    }
}

