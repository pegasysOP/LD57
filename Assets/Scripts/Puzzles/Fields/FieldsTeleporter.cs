using UnityEngine;

public class FieldsTeleporter : MonoBehaviour
{
    public Transform destinationTransform;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Vector3 playerPosition = GameManager.Instance.playerController.transform.position;
            Vector3 offset = playerPosition - transform.position;
            GameManager.Instance.playerController.transform.position = destinationTransform.position + offset;
        }
    }
}
