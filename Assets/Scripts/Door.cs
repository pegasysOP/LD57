using UnityEngine;

public enum DoorState
{
    Open,
    Closed,
    Locked
}

public class Door : MonoBehaviour, IInteractable
{
    public Animator animator;

    public DoorState state = DoorState.Closed;

    public void Interact()
    {
        switch (state)
        {
            case DoorState.Open:
                CloseDoor();
                break;
            case DoorState.Closed:
                OpenDoor();
                break;
            case DoorState.Locked:
                ShowLockedAnimation();
                break;
        }

    }

    public void OpenDoor()
    {
        state = DoorState.Open;
        animator.SetTrigger("Open");
    }

    public void CloseDoor()
    {
        state = DoorState.Closed;
        animator.SetTrigger("Close");
    }

    public void ShowLockedAnimation()
    {
        //animator.SetTrigger("Locked");
    }

    public void CloseToLocked()
    {
        state = DoorState.Locked;
        animator.SetTrigger("Close");
    }
}
