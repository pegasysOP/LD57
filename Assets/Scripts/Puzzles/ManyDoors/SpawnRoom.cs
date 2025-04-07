using System.Collections;
using UnityEngine;

public class SpawnRoom : Door
{
    public GameObject room;
    public bool correctDoor;
    public Vector3 offset;

    public CanvasGroup fadeCanvasGroup;
    public float fadeDuration = 2f;

    public Vector3 lastOffset = new Vector3(0, 0, 0);

    private Vector3 initialPosition;

    public void Start()
    {
        if(room != null)
        {
            initialPosition = room.transform.position;
        }
        
    }

    public override void Interact()
    {
        if (correctDoor)
        {
            StartCoroutine(FadeToBlack()); 
        }
        
            MoveRoom(offset);
            room.SetActive(true);

        //Close all other doors
        CloseAllOtherRooms(this);

        base.Interact();
    }

    public void CloseAllOtherRooms(SpawnRoom currentRoom)
    {
        SpawnRoom[] spawnRooms = FindObjectsByType<SpawnRoom>(FindObjectsSortMode.None);

        foreach (SpawnRoom spawnRoom in spawnRooms)
        {
            if (spawnRoom != currentRoom)
            {
                spawnRoom.CloseDoor();
            }
        }
    }

    private void MoveRoom(Vector3 offset)
    {
        Vector3 adjustedOffset = initialPosition + offset; 
        room.transform.position = (adjustedOffset); //TODO: first we want to inverse the previous offset (i.e. if the offset is (0,0, 10) we want to do (0,0,-10) first. Then we add the current offset to it)
        lastOffset = offset;

        //TODO: close all other doors when you open a door and also have the walls be smaller
    }

    public override bool IsInteractable()
    {
        return true;
    }

    public IEnumerator FadeToBlack()
    {
        float timer = 0f;

        // Make sure the fade overlay is visible
        fadeCanvasGroup.gameObject.SetActive(true);

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            fadeCanvasGroup.alpha = Mathf.Lerp(0f, 1f, timer / fadeDuration);
            yield return null;
        }

        fadeCanvasGroup.alpha = 1f;
        SceneUtils.LoadMenuScene();
    }
}

