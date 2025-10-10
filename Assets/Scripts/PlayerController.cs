using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] Camera playerCamera;
    Rigidbody rb;
    RaycastHit hit = new RaycastHit();
    bool isGrounded;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        GetComponent<Renderer>().enabled = false;
    }

    void FixedUpdate()
    {
        Move();
        Jump();
    }

    private void Jump()
    {
        Debug.DrawRay(transform.position, Vector3.down * 1.1f, Color.red);
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.1f))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        if (Input.GetButton("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * 5, ForceMode.Impulse);
        }
    }

    private void Move(){
        // Get input
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 input = new Vector3(h, 0, v);
        if (input.magnitude > 1) input.Normalize();

        // Get camera's forward and right, ignoring pitch
        Vector3 camForward = playerCamera.transform.forward;
        Vector3 camRight = playerCamera.transform.right;
        camForward.y = 0;
        camRight.y = 0;
        camForward.Normalize();
        camRight.Normalize();

        // Calculate move direction relative to camera
        Vector3 moveDir = camForward * input.z + camRight * input.x;
        Vector3 move = speed * Time.fixedDeltaTime * moveDir;
        rb.MovePosition(rb.position + move);
    }
}