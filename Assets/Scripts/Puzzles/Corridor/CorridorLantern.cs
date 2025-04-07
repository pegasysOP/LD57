using UnityEngine;

public class CorridorLantern : MonoBehaviour
{
    public Light lanternLight;
    public float lightOffDistance = 105;
    public float lightOnDistance = 90;

    private void Update()
    {
        Vector3 playerPos = GameManager.Instance.playerController.transform.position;
        float distanceToPlayer = Vector3.Distance(playerPos, transform.position);
        float clampedDistance = Mathf.Clamp(distanceToPlayer, lightOnDistance, lightOffDistance);

        lanternLight.intensity = 1 - ((clampedDistance - lightOnDistance) / (lightOffDistance - lightOnDistance));
    }
}
