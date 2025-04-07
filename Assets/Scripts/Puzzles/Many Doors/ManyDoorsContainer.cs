using System;
using UnityEngine;

public class ManyDoorsContainer : MonoBehaviour
{
    public GameObject aheadRoom;
    public GameObject behindRoom;

    public ManyDoorsDoorway[] exitDoorways;

    private void Awake()
    {
        foreach (ManyDoorsDoorway doorway in exitDoorways)
        {
            doorway.DoorOpened.AddListener(OnDoorOpened);
        }
    }

    private void OnDoorOpened(Vector3 doorLocation)
    {
        Vector3 aheadRoomPos = aheadRoom.transform.position;
        aheadRoomPos.z = doorLocation.z;
        aheadRoom.transform.position = aheadRoomPos;

        Vector3 behindRoomPos = behindRoom.transform.position;
        behindRoomPos.z = -doorLocation.z;
        behindRoom.transform.position = behindRoomPos;
    }
}
