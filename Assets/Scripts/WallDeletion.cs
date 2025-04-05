using UnityEngine;

public class WallDeletion : MonoBehaviour, IInteractable
{
    public GameObject wall;

    public void Interact()
    {
        wall.SetActive(false);
    }
}
