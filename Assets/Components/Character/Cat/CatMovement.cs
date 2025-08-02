using UnityEngine;
using UnityEngine.InputSystem;

public class CatMovement : MonoBehaviour
{
    private PlayerControls controls;
    private Rigidbody2D rb;
    private Animator animator;

    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    private float horizontalMovement;
    private bool isGrounded;
    private bool jumpPressed;

    public Transform groundCheck;
    public LayerMask groundLayer;
    public float groundCheckRadius = 0.3f;
    private Vector3 originalScale;

    void Awake()
    {
        controls = new PlayerControls();

        controls.CatControls.Move.performed += ctx => horizontalMovement = ctx.ReadValue<Vector2>().x;
        controls.CatControls.Move.canceled += ctx => horizontalMovement = 0;

        controls.CatControls.Jump.performed += ctx => jumpPressed = true; // Flag jump press
    }

    void OnEnable() => controls.CatControls.Enable();
    void OnDisable() => controls.CatControls.Disable();

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        originalScale = transform.localScale;
    }

    void Update()
    {
        // Ground check
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Horizontal movement
        rb.linearVelocity = new Vector2(horizontalMovement * moveSpeed, rb.linearVelocity.y);

        // Jump logic
        if (jumpPressed && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce); // Apply jump force
            jumpPressed = false; // Reset jump flag to prevent continuous jumping
        }

        // Animator parameters
        animator.SetFloat("Speed", Mathf.Abs(horizontalMovement)); // Speed set for walking/running animation
        animator.SetBool("IsGrounded", isGrounded);
        animator.SetBool("IsJumping", !isGrounded);

        // Flip character based on movement direction
        if (horizontalMovement > 0.01f)
            transform.localScale = new Vector3(Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);
        else if (horizontalMovement < -0.01f)
            transform.localScale = new Vector3(-Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);
    }

    void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius); // Display ground check in the editor
        }
    }
}
