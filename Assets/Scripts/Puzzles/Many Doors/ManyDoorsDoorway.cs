using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class ManyDoorsDoorway : MonoBehaviour
{
    public Door door;

    public UnityEvent<ManyDoorsDoorway> DoorOpened;

    public bool isFinalDoor = false;


    private void Awake()
    {
        door.DoorOpened.AddListener(OnDoorOpened);
    }

    private void Start()
    {
        InvokeRepeating(nameof(playSound), 0, 5);
    }

    private void Update()
    {
        
    }

    private void playSound()
    {
        if (isFinalDoor)
        {
            AudioSource source = this.gameObject.GetComponent<AudioSource>();
            source.PlayOneShot(source.clip);
        }
    }

    private void OnDoorOpened()
    {
        DoorOpened?.Invoke(this);
    }
}
