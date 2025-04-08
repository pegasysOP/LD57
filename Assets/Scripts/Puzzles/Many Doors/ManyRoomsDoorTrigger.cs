using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class ManyRoomsDoorTrigger : MonoBehaviour
{
    public Collider trigger;

    private Door selectedDoor;
    private List<ManyDoorsDoorway> otherDoorways;

    public void Init(Door selectedDoor, List<ManyDoorsDoorway> otherDoorways)
    {
        this.selectedDoor = selectedDoor;
        this.otherDoorways = otherDoorways;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            trigger.enabled = false;

            selectedDoor.CloseToLocked();

            foreach (ManyDoorsDoorway doorway in otherDoorways)
            {
                doorway.gameObject.SetActive(false);
            }
        }
    }

    public void Reset()
    {
        selectedDoor = null;
        otherDoorways = null;

        trigger.enabled = true;
    }
}
