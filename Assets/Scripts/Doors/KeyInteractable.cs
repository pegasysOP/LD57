using UnityEngine;

public class KeyInteractable : MonoBehaviour, IInteractable
{
    public KeyDoor keyDoor;

    public void Interact()
    {
        keyDoor.SetKey();
        gameObject.SetActive(false);
        GameManager.Instance.hud.ShowKeyIcon(true);
    }

    public bool IsInteractable()
    {
        return true;
    }
}
