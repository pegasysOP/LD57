using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;

public class ManyDoorsDoorway : MonoBehaviour
{
    public Door door;

    public UnityEvent<ManyDoorsDoorway> DoorOpened;

    public bool isFinalDoor = false;

    public AudioClip[] dreamClips;


    private void Awake()
    {
        door.DoorOpened.AddListener(OnDoorOpened);
    }

    private void Start()
    {
        InvokeRepeating(nameof(playSound), 0, 5);
    }


    private void playSound()
    {
        if (isFinalDoor)
        {
            AudioSource source = this.gameObject.GetComponent<AudioSource>();
            int rand = UnityEngine.Random.Range(0, dreamClips.Length);
            source.PlayOneShot(dreamClips[rand]);
        }
    }

    private void OnDoorOpened()
    {
        DoorOpened?.Invoke(this);
    }
}
