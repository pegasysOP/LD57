using System;
using UnityEngine;
using UnityEngine.Events;

public class ManyDoorsDoorway : MonoBehaviour
{
    public Door door;

    public UnityEvent<ManyDoorsDoorway> DoorOpened;

    private void Awake()
    {
        door.DoorOpened.AddListener(OnDoorOpened);
    }

    private void OnDoorOpened()
    {
        DoorOpened?.Invoke(this);
    }
}
