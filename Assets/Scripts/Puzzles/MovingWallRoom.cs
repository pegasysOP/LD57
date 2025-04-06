using UnityEngine;

public class MovingWallRoom : MonoBehaviour
{
    public Door frontDoor;
    public Collider frontDoorCloseTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            frontDoorCloseTrigger.enabled = false;
            frontDoor.CloseToLocked();
        }
    }
}
