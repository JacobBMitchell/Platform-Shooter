using UnityEngine;

public class CameraRelativePlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] Camera playerCamera;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Get input
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 input = new Vector3(h, 0, v);
        if (input.magnitude > 1) input.Normalize();

        // Get camera's forward and right, ignore y for ground movement
        Vector3 camForward = playerCamera.transform.forward;
        Vector3 camRight = playerCamera.transform.right;
        camForward.y = 0;
        camRight.y = 0;
        camForward.Normalize();
        camRight.Normalize();

        // Move relative to camera
        Vector3 move = (camForward * input.z + camRight * input.x) * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + move);
    }
}