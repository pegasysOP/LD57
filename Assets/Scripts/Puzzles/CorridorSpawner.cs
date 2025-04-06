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
    private float spawnLocation;

    private bool complete = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        spawnLocation = segmentLength / 2;

        // Spawn the initial buffer of corridor segments
        for (int i = 0; i < forwardBuffer; i++)
            SpawnCorridor();
    }

    private void Update()
    {
        if (complete)
            return;

        Vector3 playerPos = GameManager.Instance.playerController.transform.position;

        MoveEndDoor(playerPos.z);

        // Spawn new corridor if player is getting close to the end of current ones
        if (playerPos.z + (forwardBuffer * segmentLength) > spawnLocation)
        {
            SpawnCorridor();
        }
    }

    private void MoveEndDoor(float playerZ)
    {
        if (complete)
         return;

        // Move doorway to always stay buffer-lengths ahead of player
        endWall.transform.position = new Vector3(
            endWall.transform.position.x,
            endWall.transform.position.y,
            playerZ + (segmentLength * (forwardBuffer - 1.5f))
        );
    }

    private void SpawnCorridor()
    {
        GameObject corridor = Instantiate(segmentPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z + spawnLocation), Quaternion.identity, transform);
        spawnedCorridors.Add(corridor);
        spawnLocation += segmentLength;
    }

    public void CleanExcessSegments()
    {
        int idealLength = (forwardBuffer + behindBuffer);

        for (int i = spawnedCorridors.Count - 1; i >= idealLength; i--)
        {
            Destroy(spawnedCorridors[i]);
            spawnedCorridors.RemoveAt(i);
        }

        spawnLocation = (spawnedCorridors.Count + 0.5f) * segmentLength;
    }

    public void SetComplete()
    {
        complete = true;
    }
}
