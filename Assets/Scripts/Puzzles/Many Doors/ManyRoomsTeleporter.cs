using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class ManyRoomsTeleporter : MonoBehaviour
{
    public Collider trigger;
    public Transform tpTarget;

    public UnityEvent Teleported;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Vector3 playerPosition = GameManager.Instance.playerController.transform.position;
            playerPosition.x = playerPosition.x - (transform.position.x - tpTarget.position.x);
            playerPosition.z = playerPosition.z - (transform.position.z - tpTarget.position.z);
            playerPosition.y = playerPosition.y - 7;
            GameManager.Instance.playerController.transform.position = playerPosition;

            Teleported?.Invoke();
        }
    }
}
