using System.Collections;
using UnityEngine;
using UnityEngine.Events;

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
    public UnityEvent DoorOpened;

    public GameObject objectToEnable;
    public GameObject objectToDisable;

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
        objectToEnable?.SetActive(true);

        DoorOpened?.Invoke();
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
        StartCoroutine(WaitThenDisableObject());
    }

    private IEnumerator WaitThenDisableObject()
    {
        yield return new WaitForSeconds(1f);
        objectToDisable?.SetActive(false);
    }
}
