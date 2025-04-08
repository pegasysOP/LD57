using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class ManyRoomsEntrance : MonoBehaviour
{
    public Collider trigger;
    public Transform manyDoorsContainer;
    public Door entranceDoor;
    public GameObject aheadRoom;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            trigger.enabled = false;

            manyDoorsContainer.transform.parent = null;

            entranceDoor.CloseToLocked();

            aheadRoom.SetActive(true);

            StartCoroutine(WaitThenDisableObject());
        }
    }

    private IEnumerator WaitThenDisableObject()
    {
        yield return new WaitForSeconds(1f);
        FindFirstObjectByType<FieldsContainer>().gameObject.SetActive(false);
    }
}
