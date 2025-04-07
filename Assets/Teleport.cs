using UnityEngine;

public class Teleport : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject destination;
    public GameObject player;

    public GameObject secondRoom;

    public GameObject spawnRoom;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Something collided");
        if(other.gameObject.layer == 9)
        {
            Debug.Log("Player is teleported");
            player.transform.position = destination.transform.position;
            secondRoom.SetActive(false);
            //spawnRoom.GetComponent<SpawnRoom>().state = DoorState.Closed;
        }
    }
}
