using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera playerCamera;
    public float yaw;
    public float pitch;
    public float mouseSensitivity;
    public float maxLookAngle;

    private void Awake()
    {
        //Application.targetFrameRate = 60;
    }

    private void Update()
    {
        yaw = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * mouseSensitivity;
        pitch -= mouseSensitivity * Input.GetAxis("Mouse Y");
        pitch = Mathf.Clamp(pitch, -maxLookAngle, maxLookAngle);
    }

    private void FixedUpdate()
    {
        transform.localEulerAngles = new Vector3(0, yaw, 0);
        playerCamera.transform.localEulerAngles = new Vector3(pitch, 0, 0);
    }
}
