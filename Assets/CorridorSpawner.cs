using System.Collections.Generic;
using UnityEngine;

public class CorridorSpawner : MonoBehaviour
{
    public GameObject corridorPrefab;
    public GameObject doorwayPrefab;
    public int corridorLength = 5;
    private int lastZSpawned = 10;
    private List<GameObject> spawnedCorridors = new List<GameObject>();
    public Vector3 lastPlayerPos;

    public int buffer = 3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Spawn in 3 corridors. 
    }

    // Update is called once per frame
    void Update()
    {
        if(lastPlayerPos == null)
        {
            lastPlayerPos = GameManager.Instance.playerController.transform.position;
        }
        //Get players position 
        Vector3 playerPos = GameManager.Instance.playerController.transform.position;
        //When the player passes some threshold. Spawn in a new corridor
        if (playerPos.z + (buffer * corridorLength) > lastZSpawned)
        {
            SpawnCorridor(lastZSpawned);
        }

        if(playerPos.z - lastPlayerPos.z > 0)
        {
            doorwayPrefab.transform.Translate(new Vector3(0, 0, playerPos.z - lastPlayerPos.z));
            lastPlayerPos = playerPos;
        }
        
        //TODO: Delete old corridors? 
    }

    void SpawnCorridor(int zPosition)
    {
        GameObject corridor = Instantiate(corridorPrefab, new Vector3(0, 0, zPosition), Quaternion.identity);
        spawnedCorridors.Add(corridor);
        lastZSpawned = zPosition + corridorLength;
    }
}
