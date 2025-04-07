using System;
using UnityEngine;
using UnityEngine.Events;

public class ManyDoorsDoorway : MonoBehaviour
{
    public Door door;

    public UnityEvent<Vector3> DoorOpened;

    private void Awake()
    {
        door.DoorOpened.AddListener(OnDoorOpened);
    }

    private void OnDoorOpened()
    {
        DoorOpened?.Invoke(transform.position);
    }
}
