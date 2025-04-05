using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public Rigidbody rb;
    public float moveSpeed;
    public float moveAcceleration;
    public float maxVelocity;

    [Header("Jumping")]
    public GroundDetector groundDetector;
    public float jumpForce;
    public float airAcceleration;

    [Header("Debug")]
    public Vector3 inputDir;
    public float speedDebug;
    public bool groundDebug;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && groundDetector.IsGrounded)
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        inputDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
    }

    private void FixedUpdate()
    {
        Vector3 moveDir = transform.TransformDirection(inputDir.normalized);
        float velocityX = Mathf.Clamp(moveDir.x * moveSpeed, -maxVelocity, maxVelocity);
        float velocityZ = Mathf.Clamp(moveDir.z * moveSpeed, -maxVelocity, maxVelocity);
        Vector3 targetVelocity = new Vector3(velocityX, rb.linearVelocity.y, velocityZ);

        float currentAcceleration = groundDetector.IsGrounded ? moveAcceleration : airAcceleration;
        rb.linearVelocity = Vector3.Lerp(rb.linearVelocity, targetVelocity, currentAcceleration * Time.deltaTime);

        Vector3 gravity = -groundDetector.GroundNormal * Physics.gravity.magnitude * rb.mass;
        rb.AddForce(gravity, ForceMode.Acceleration);

        speedDebug = rb.linearVelocity.magnitude;
        groundDebug = groundDetector.IsGrounded;
    }
}