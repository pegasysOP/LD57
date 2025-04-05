using System.Collections.Generic;
using UnityEngine;

public class CorridorSpawner : MonoBehaviour
{
    public GameObject corridorPrefab;
    public int corridorLength = 20;
    private int lastZSpawned = 0;
    private List<GameObject> spawnedCorridors = new List<GameObject>();

    public int buffer = 3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Spawn in 3 corridors. 
    }

    // Update is called once per frame
    void Update()
    {
        //Get players position 
        Vector3 playerPos = GameManager.Instance.playerController.transform.position;
        //When the player passes some threshold. Spawn in a new corridor
        if (Input.GetKeyDown(KeyCode.S))
        {
            Instantiate(corridorPrefab, this.transform.position, Quaternion.identity);
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
