using System.Collections.Generic;
using UnityEngine;

public class CorridorSpawner : MonoBehaviour
{
    public GameObject corridorPrefab;
    public GameObject doorwayPrefab;
    public int corridorLength = 5;
    private int lastZSpawned = 0;
    private List<GameObject> spawnedCorridors = new List<GameObject>();
    public Vector3 lastPlayerPos;

    public int buffer = 10;

    private float corridorCleanupDistance => 3 * corridorLength;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Spawn the initial buffer of corridor segments
        for (int i = 0; i < buffer; i++)
        {
            SpawnCorridor(i * corridorLength);
        }

        lastZSpawned = buffer * corridorLength;

        // Position the doorway ahead of the player
        doorwayPrefab.transform.position = new Vector3(
            doorwayPrefab.transform.position.x,
            doorwayPrefab.transform.position.y,
            GameManager.Instance.playerController.transform.position.z + (corridorLength * buffer)
        );


        // Store initial player position
        lastPlayerPos = GameManager.Instance.playerController.transform.position;
    }

    void Update()
    {
        Vector3 playerPos = GameManager.Instance.playerController.transform.position;

        // Spawn new corridor if player is getting close to the end of current ones
        if (playerPos.z + (buffer * corridorLength) > lastZSpawned)
        {
            SpawnCorridor(lastZSpawned);
        }

        // Move doorway to always stay buffer-lengths ahead of player
        doorwayPrefab.transform.position = new Vector3(
            doorwayPrefab.transform.position.x,
            doorwayPrefab.transform.position.y,
            playerPos.z + (corridorLength * buffer)
        );

        CleanupOldCorridors(playerPos.z);

        lastPlayerPos = playerPos;

        // Optional TODO: Remove/destroy corridor segments that are far behind
    }

    void SpawnCorridor(int zPosition)
    {
        GameObject corridor = Instantiate(corridorPrefab, new Vector3(0, 0, zPosition), Quaternion.identity);
        spawnedCorridors.Add(corridor);
        lastZSpawned = zPosition + corridorLength;
    }

    void CleanupOldCorridors(float playerZ)
    {
        for (int i = spawnedCorridors.Count - 1; i >= 0; i--)
        {
            GameObject corridor = spawnedCorridors[i];
            if (playerZ - corridor.transform.position.z > corridorCleanupDistance)
            {
                Destroy(corridor);
                spawnedCorridors.RemoveAt(i);
            }
        }
    }
}
