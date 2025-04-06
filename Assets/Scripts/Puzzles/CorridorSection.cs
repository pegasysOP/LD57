using UnityEngine;

public class CorridorSection : MonoBehaviour
{
    public CorridorSpawner spawner;
    public GameObject area1;
    public GameObject area2;

    public float activationDistance = 30f;
    public float activationAngle = 60f;

    private bool activated = false;
    private bool complete = false;

    private void Update()
    {
        if (complete)
            return;

        Vector3 playerPos = GameManager.Instance.playerController.transform.position;
        
        // check player facing away from entrance
        Vector3 directionToPlayer = (playerPos - transform.position);
        directionToPlayer.y = 0;
        directionToPlayer.Normalize();

        Vector3 playerFacingDirection= GameManager.Instance.cameraController.transform.forward;
        playerFacingDirection.y = 0;
        playerFacingDirection.Normalize();

        if (Vector3.Angle(directionToPlayer, playerFacingDirection) > activationAngle)
            return;

        if (activated)
        {
            Shift();

            return;
        }

        // check if player walked far enough
        float distanceToPlayer = Vector3.Distance(playerPos, transform.position);
        if (distanceToPlayer < activationDistance)
            return;

        // switch over to the next area
        activated = true;
        area1.SetActive(false);
        area2.SetActive(true);
    }

    private void Shift()
    {
        Vector3 playerPos = GameManager.Instance.playerController.transform.position;

        // only tp beyond activation distance
        float distanceToPlayer = playerPos.z - transform.position.z;
        if (distanceToPlayer < activationDistance)
            return;

        //move player nearer to start
        float distanceIntoSegment = (playerPos.z - transform.position.z) % spawner.segmentLength;
        int activationSegment = Mathf.FloorToInt(activationDistance / spawner.segmentLength);
        playerPos.z = transform.position.z + activationSegment * spawner.segmentLength + distanceIntoSegment;

        GameManager.Instance.playerController.transform.position = playerPos;

        spawner.CleanExcessSegments();
    }

    public void SetComplete()
    {
        complete = true;
        spawner.SetComplete();
    }
}
