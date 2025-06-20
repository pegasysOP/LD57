using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ManyDoorsContainer : MonoBehaviour
{
    public ManyRoomsDoorTrigger doorTrigger;
    public ManyRoomsTeleporter teleporter;

    public GameObject aheadRoom;
    public GameObject mainRoom;

    public float fadeDuration = 2f;

    public List<ManyDoorsDoorway> exitDoorways;

    private bool limitReached = false;


    private void Awake()
    {
        teleporter.Teleported.AddListener(OnTeleported);
        doorTrigger.LimitReached.AddListener(OnLimitReached);

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

    private void OnLimitReached()
    {
        limitReached = true;

        //Select one of the doors at random to be the winning door 

        ManyDoorsDoorway door = exitDoorways[UnityEngine.Random.Range(0, exitDoorways.Count)];
        door.isFinalDoor = true;
        AudioSource source = door.AddComponent<AudioSource>();
        source.playOnAwake = false;
        source.spatialBlend = 1;
    }

    private void OnDoorOpened(ManyDoorsDoorway selectedDoorway)
    {
        if (limitReached && selectedDoorway.isFinalDoor)
        {
            MoveRoom(selectedDoorway);
            StartCoroutine(FadeToBlack());
            return;
        }
        MoveRoom(selectedDoorway);

    }

    public void MoveRoom(ManyDoorsDoorway selectedDoorway)
    {
        // move rooms
        Vector3 aheadRoomPos = aheadRoom.transform.localPosition - mainRoom.transform.localPosition;
        aheadRoomPos.z = mainRoom.transform.localPosition.z + selectedDoorway.transform.localPosition.z;
        aheadRoom.transform.localPosition = aheadRoomPos;

        List<ManyDoorsDoorway> otherDoorways = new List<ManyDoorsDoorway>(exitDoorways);
        otherDoorways.Remove(selectedDoorway);

        foreach (ManyDoorsDoorway doorway in otherDoorways)
            doorway.door.InstantClose();


        doorTrigger.Init(selectedDoorway.door, otherDoorways);
    }

    public IEnumerator FadeToBlack()
    {
        float timer = 0f;

        AudioManager.Instance.Stop(AudioManager.Instance.musicSource, true, 1f);

        // Make sure the fade overlay is visible
        GameManager.Instance.hud.fadeToBlack.alpha = 0f;
        GameManager.Instance.hud.fadeToBlack.gameObject.SetActive(true);

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            GameManager.Instance.hud.fadeToBlack.alpha = Mathf.Lerp(0f, 1f, timer / fadeDuration);
            yield return null;
        }

        GameManager.Instance.hud.fadeToBlack.alpha = 1f;
        SceneUtils.LoadCreditScene();
    }
}
