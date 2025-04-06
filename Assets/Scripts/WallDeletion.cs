using UnityEngine;

public class WallDeletion : MonoBehaviour, IInteractable
{
    public GameObject wall;

    public void Interact()
    {
        wall.SetActive(false);
    }

    public bool IsInteractable()
    {
        return true;
    }
}
