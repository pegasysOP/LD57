using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Vector3 offset;

    private void Start()
    {
        offset = transform.position;
    }

    private void Update()
    {
        Vector3 playerPosition = GameManager.Instance.playerController.transform.position;
        playerPosition.y = 0;

        transform.position = playerPosition + offset;
    }
}
