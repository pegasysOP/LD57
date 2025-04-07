using UnityEngine;

public class KeyDoor : Door
{
    public GameObject keyObject;

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
