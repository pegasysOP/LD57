using UnityEngine;

public class CorridorSection : MonoBehaviour
{
    public CorridorSpawner spawner;
    public GameObject area1;
    public GameObject area2;

    public float minActivationDistance = 30f;
    public float activationAngle = 60f;

    private bool activated = false;

    private void Update()
    {
        if (activated)
            return;

        // check if player walked far enough
        Vector3 playerPos = GameManager.Instance.playerController.transform.position;
        float distanceToPlayer = Vector3.Distance(playerPos, transform.position);
        if (distanceToPlayer < minActivationDistance)
            return;

        // check player facing away from entrance
        Vector3 directionToPlayer = (playerPos - transform.position);
        directionToPlayer.y = 0;
        directionToPlayer.Normalize();

        Vector3 playerFacingDirection= GameManager.Instance.cameraController.transform.forward;
        playerFacingDirection.y = 0;
        playerFacingDirection.Normalize();

        if (Vector3.Angle(directionToPlayer, playerFacingDirection) > activationAngle)
            return;

        area1.SetActive(false);
        area2.SetActive(true);
        activated = true;
    }
}
