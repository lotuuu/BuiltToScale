using UnityEngine;

public class Builder : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    float horizontalInput;
    bool jumpInput;

    new Rigidbody2D rigidbody2D;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        GatherInput();
        HandleMovement();
        HandleJump();
    }

    void HandleMovement()
    {
        Vector2 newVelocity = new(horizontalInput * moveSpeed, rigidbody2D.velocity.y);
        rigidbody2D.velocity = newVelocity;
    }

    void HandleJump()
    {
        if (jumpInput)
        {
            Jump();
            jumpInput = false;
        }
    }

    void Jump()
    {
        // Debug.Log("Jumping!");
    }

    void GatherInput()
    {
        horizontalInput = Input.GetAxis("HorizontalBuilder");
        jumpInput = Input.GetButtonDown("JumpBuilder");
    }
}
