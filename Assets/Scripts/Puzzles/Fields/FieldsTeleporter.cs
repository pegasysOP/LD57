using UnityEngine;

public class FieldsTeleporter : MonoBehaviour
{
    public Transform destinationTransform;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Vector3 playerPosition = GameManager.Instance.playerController.transform.position;
            playerPosition.x = destinationTransform.position.x;
            GameManager.Instance.playerController.transform.position = playerPosition;
        }
    }
}
