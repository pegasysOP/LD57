using UnityEngine;

public class KeyDoor : Door
{
    public GameObject keyObject;
    public GameObject facade;

    private bool hasKey = false;

    public override void Interact()
    {
        if (state == DoorState.Locked)
        {
            if (hasKey)
            {
                keyObject.SetActive(true);
                GameManager.Instance.hud.ShowKeyIcon(false);
                OpenDoor();
                facade.SetActive(true);
            }
            else
            {
                ShowLockedAnimation();
            }
        }
    }

    public override bool IsInteractable()
    {
        return state != DoorState.Open;
    }

    public void SetKey()
    {
        hasKey = true;
    }
}
