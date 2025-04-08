using UnityEngine;

public class MuseumLockDoor : MonoBehaviour
{
    public Collider trigger;
    public Door targetDoor;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            trigger.enabled = false;
            targetDoor.CloseToLocked();
        }
    }
}
