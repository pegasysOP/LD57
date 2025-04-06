using UnityEngine;

public class CameraToggleZone : MonoBehaviour
{
    public MuseumSection museumController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.cameraController.playerCamera.orthographic = true;
            museumController.SetScanning(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.cameraController.playerCamera.orthographic = false;
            museumController.SetScanning(false);
        }
    }
}
