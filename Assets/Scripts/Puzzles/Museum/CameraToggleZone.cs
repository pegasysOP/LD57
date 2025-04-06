using UnityEngine;

public class CameraToggleZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.cameraController.playerCamera.orthographic = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.cameraController.playerCamera.orthographic = false;
        }
    }
}
