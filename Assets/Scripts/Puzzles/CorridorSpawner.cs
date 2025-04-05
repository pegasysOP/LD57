using System.Collections.Generic;
using UnityEngine;

public class CorridorSpawner : MonoBehaviour
{
    public GameObject segmentPrefab;
    public GameObject endWall;

    public int forwardBuffer = 10;
    public int behindBuffer = 3;
    public int segmentLength;


    private List<GameObject> spawnedCorridors = new List<GameObject>();
    private int lastZSpawned = 0;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Spawn the initial buffer of corridor segments
        for (int i = 0; i < forwardBuffer; i++)
        {
            SpawnCorridor(i * segmentLength);
        }

        lastZSpawned = forwardBuffer * segmentLength;
    }

    void Update()
    {
        Vector3 playerPos = GameManager.Instance.playerController.transform.position;

        // Spawn new corridor if player is getting close to the end of current ones
        if (playerPos.z + (forwardBuffer * segmentLength) > lastZSpawned)
        {
            SpawnCorridor(lastZSpawned);
        }

        // Move doorway to always stay buffer-lengths ahead of player
        endWall.transform.position = new Vector3(
            endWall.transform.position.x,
            endWall.transform.position.y,
            playerPos.z + (segmentLength * forwardBuffer)
        );

        CleanupOldCorridors(playerPos.z);
    }

    void SpawnCorridor(int zPosition)
    {
        GameObject corridor = Instantiate(segmentPrefab, new Vector3(0, 0, zPosition), Quaternion.identity, transform);
        spawnedCorridors.Add(corridor);
        lastZSpawned = zPosition + segmentLength;
    }

    void CleanupOldCorridors(float playerZ)
    {
        for (int i = spawnedCorridors.Count - 1; i >= 0; i--)
        {
            GameObject corridor = spawnedCorridors[i];
            if (playerZ - corridor.transform.position.z > segmentLength * behindBuffer)
            {
                Destroy(corridor);
                spawnedCorridors.RemoveAt(i);
            }
        }
    }
}
