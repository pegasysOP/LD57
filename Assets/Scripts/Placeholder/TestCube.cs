using UnityEngine;

public class TestCube : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Debug.Log("TestCube Interacted");
    }

    public bool IsInteractable()
    {
        return true;
    }
}
