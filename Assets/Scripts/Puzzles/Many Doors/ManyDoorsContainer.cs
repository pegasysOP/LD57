using System;
using System.Collections.Generic;
using UnityEngine;

public class ManyDoorsContainer : MonoBehaviour
{
    public ManyRoomsDoorTrigger doorTrigger;
    public ManyRoomsTeleporter teleporter;

    public GameObject aheadRoom;
    public GameObject mainRoom;

    public List<ManyDoorsDoorway> exitDoorways;

    private void Awake()
    {
        teleporter.Teleported.AddListener(OnTeleported);

        foreach (ManyDoorsDoorway doorway in exitDoorways)
        {
            doorway.DoorOpened.AddListener(OnDoorOpened);
        }
    }

    private void OnTeleported()
    {
        doorTrigger.Reset();

        foreach (ManyDoorsDoorway doorway in exitDoorways)
        {
            doorway.gameObject.SetActive(true);
            doorway.door.InstantClose();
        }
    }

    private void OnDoorOpened(ManyDoorsDoorway selectedDoorway)
    {
        // move rooms
        Vector3 aheadRoomPos = aheadRoom.transform.localPosition - mainRoom.transform.localPosition;
        aheadRoomPos.z = mainRoom.transform.localPosition.z + selectedDoorway.transform.localPosition.z;
        aheadRoom.transform.localPosition = aheadRoomPos;

        List<ManyDoorsDoorway> otherDoorways = new List<ManyDoorsDoorway>(exitDoorways);
        otherDoorways.Remove(selectedDoorway);

        doorTrigger.Init(selectedDoorway.door, otherDoorways);
    }
}
