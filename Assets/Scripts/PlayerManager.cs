using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;
    public GameObject leftPlayerPrefab, rightPlayerPrefab;
    public Transform leftSpawnPoint, rightSpawnPoint;
    public float spawnOffsetY = 1.5f;

    private List<GameObject> leftPlayers = new List<GameObject>();
    private List<GameObject> rightPlayers = new List<GameObject>();
    public List<GameObject> leftPlayerList => leftPlayers;
    public List<GameObject> rightPlayerList => rightPlayers;

    void Start()
    {
        // Spawn one player on each side at the start
        SpawnLeftPlayer();
        SpawnRightPlayer();
    }

    public void SpawnLeftPlayer()
    {
        Vector3 spawnPosition = leftSpawnPoint.position;
        if (leftPlayers.Count > 0)
        {
            GameObject lastPlayer = leftPlayers[leftPlayers.Count - 1];
            spawnPosition = lastPlayer.transform.position + new Vector3(0, spawnOffsetY, 0);
        }
        GameObject newLeftPlayer = Instantiate(leftPlayerPrefab, spawnPosition, Quaternion.identity);
        newLeftPlayer.tag = "LeftPlayer";
        leftPlayers.Add(newLeftPlayer);
        
    }

    public void SpawnRightPlayer()
    {
        Vector3 spawnPosition = rightSpawnPoint.position;
        if (rightPlayers.Count > 0)
        {
            GameObject lastPlayer = rightPlayers[rightPlayers.Count - 1];
            spawnPosition = lastPlayer.transform.position + new Vector3(0, spawnOffsetY, 0);
        }
        GameObject newRightPlayer = Instantiate(rightPlayerPrefab, spawnPosition, Quaternion.identity);
        newRightPlayer.tag = "RightPlayer";
        rightPlayers.Add(newRightPlayer);
    }

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void AddSoldier(string colliderTag)
    {
        if (colliderTag == "LeftBullet")
        {
            SpawnLeftPlayer();
        }
        else if (colliderTag == "RightBullet")
        {
            SpawnRightPlayer();
        }
    }
}