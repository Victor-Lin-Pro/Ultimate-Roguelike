using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 8f;

    private Rigidbody rb;
    private Vector2 moveInput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Called by the PlayerControls actions
    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed) // Just pressed
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        Vector3 movement = new Vector3(moveInput.x, 0, moveInput.y) * moveSpeed;
        rb.linearVelocity = new Vector3(movement.x, rb.linearVelocity.y, movement.z);
    }

    private void Jump()
    {
        // Simple jump - you might want to add ground check
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z);
    }
}
