using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera playerCamera;
    public float yaw;
    public float pitch;
    public float mouseSensitivity;
    public float maxLookAngle;

    private float sensitivitySetting = 1f;
    private bool locked = false;

    private void Awake()
    {
        sensitivitySetting = SettingsUtils.GetSensitivity();
    }

    private void Start()
    {
        if (GameManager.Instance.cameraController)
            Debug.LogError("WARNING: Duplicate camera controller instances in scene");

        GameManager.Instance.cameraController = this;
    }

    private void Update()
    {
        if (locked)
            return;

        yaw = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * mouseSensitivity * sensitivitySetting;
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity * sensitivitySetting;
        pitch = Mathf.Clamp(pitch, -maxLookAngle, maxLookAngle);

        transform.localEulerAngles = new Vector3(0, yaw, 0);
        playerCamera.transform.localEulerAngles = new Vector3(pitch, 0, 0);
    }

    public void UpdateSensitivity(float value)
    {
        sensitivitySetting = value;
    }

    public void SetLocked(bool locked)
    {
        this.locked = locked;
    }
}
