using UnityEngine;

public class KeyInteractable : MonoBehaviour, IInteractable
{
    public KeyDoor keyDoor;

    public GameObject prefabToDisable;
    public GameObject prefabToEnable;
    public GameObject roomToDisable;

    public void Interact()
    {
        keyDoor.SetKey();
        gameObject.SetActive(false);
        GameManager.Instance.hud.ShowKeyIcon(true);
        AudioManager.Instance.PlayItemAcquireClip();
        if(prefabToDisable != null)
        {
            prefabToDisable.SetActive(false);
            roomToDisable.SetActive(false);
            prefabToEnable.SetActive(true);
        }
    }

    public bool IsInteractable()
    {
        return true;
    }
}
