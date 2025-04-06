using UnityEngine;

public class WallDeletionDoor : Door
{
    public GameObject wallToRemove;

    public override void Interact()
    {
        if (state == DoorState.Closed)
        {
            OpenDoor();
        }
        else if (state == DoorState.Locked)
        {
            ShowLockedAnimation();

            wallToRemove.SetActive(false);
        }
    }

    public override bool IsInteractable()
    {
        return state != DoorState.Open;
    }
}