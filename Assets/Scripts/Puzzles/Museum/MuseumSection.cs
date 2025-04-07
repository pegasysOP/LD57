using UnityEngine;

public class MuseumSection : MonoBehaviour
{
    public LayerMask targetLayer;
    public KeyInteractable key;

    private bool scanning = false;
    private bool complete = false;

    private void Update()
    {
        if (complete || !scanning)
            return;

        ScanForTarget();
    }

    private void ScanForTarget()
    {
        Vector3 playerCamPos = GameManager.Instance.playerInteraction.transform.position;
        Vector3 playerCamDir = GameManager.Instance.playerInteraction.transform.forward;

        Debug.DrawRay(playerCamPos, playerCamDir * 100f, Color.blue);

        if (Physics.Raycast(playerCamPos, playerCamDir, out RaycastHit hit, 100f, targetLayer))
            Complete();
    }

    public void SetScanning(bool scanning)
    {
        this.scanning = scanning;
    }

    private void Complete()
    {
        complete = true;
        key.gameObject.SetActive(true);
    }
}
