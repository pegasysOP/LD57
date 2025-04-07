using System.Collections.Generic;
using UnityEngine;

public class FieldsContainer : MonoBehaviour
{
    public GameObject museumContainer;
    public GameObject behindSegmentsContainer;
    public float activationDistance = 10f;
    public float activationAngle = 60f;

    private bool activated = false;

    private void Update()
    {
        if (activated)
            return;

        Vector3 playerPos = GameManager.Instance.playerController.transform.position;

        // check player facing away from entrance
        float distanceToPlayer = Vector3.Distance(playerPos, transform.position);
        if (distanceToPlayer < activationDistance)
            return;

        // check player facing away from entrance
        Vector3 directionToPlayer = (playerPos - transform.position);
        directionToPlayer.y = 0;
        directionToPlayer.Normalize();

        Vector3 playerFacingDirection = GameManager.Instance.cameraController.transform.forward;
        playerFacingDirection.y = 0;
        playerFacingDirection.Normalize();

        if (Vector3.Angle(directionToPlayer, playerFacingDirection) > activationAngle)
            return;

        activated = true;
        museumContainer.SetActive(false);
        behindSegmentsContainer.SetActive(true);
    }
}
