using System.Collections;
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

    public GameObject prefabToDisable;

    public GameObject prefabToEnable;

    public virtual void Interact()
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

    public virtual bool IsInteractable()
    {
        return state != DoorState.Locked;
    }

    public void OpenDoor()
    {
        state = DoorState.Open;
        animator.SetTrigger("Open");
        AudioManager.Instance.PlayDoorOpenClip();
        if(prefabToEnable != null)
        {
            prefabToEnable.SetActive(true);
        }
    }

    public void CloseDoor()
    {
        state = DoorState.Closed;
        animator.SetTrigger("Close");
        AudioManager.Instance.PlayDoorClosedClip();
    }

    public void ShowLockedAnimation()
    {
        animator.SetTrigger("Locked");
        AudioManager.Instance.PlayDoorLockedClip();
    }

    public void CloseToLocked()
    {
        state = DoorState.Locked;
        animator.SetTrigger("Close");
        AudioManager.Instance.PlayDoorClosedClip();
        if(prefabToDisable != null)
        {
            StartCoroutine(DisablePrefab());
        }
    }

    IEnumerator DisablePrefab()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            prefabToDisable.SetActive(false);
            
        }
    }
}
