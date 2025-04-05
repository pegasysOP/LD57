using UnityEngine;

public class TestCube : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Debug.Log("TestCube Interacted");
    }
}
