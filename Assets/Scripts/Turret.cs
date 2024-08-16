using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    float horizontalInput;
    bool jumpInput;

    new Rigidbody2D rigidbody2D;

    [SerializeField] float fireCooldown = 5f;
    float fireTimer;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        GatherInput();
        HandleMovement();
        HandleJump();
        HandleFire();
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

    void HandleFire()
    {
        fireTimer -= Time.deltaTime;
        if (fireTimer <= 0)
        {
            Fire();
            fireTimer = fireCooldown;
        }
    }

    void Fire()
    {
        // Debug.Log("Firing!");
    }

    void Jump()
    {
        // Debug.Log("Jumping!");
    }

    void GatherInput()
    {
        horizontalInput = Input.GetAxis("HorizontalTurret");
        jumpInput = Input.GetButtonDown("JumpTurret");
    }
}
