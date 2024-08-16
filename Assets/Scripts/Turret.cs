using UnityEngine;
using UnityEngine.InputSystem;

public class Turret : MonoBehaviour
{
    Vector2 moveInput;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float fireCooldown = 5f;

    new Rigidbody2D rigidbody2D;
    new Collider2D collider2D;

    float fireTimer = 0f;
    bool isGrounded = true;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        collider2D = GetComponent<Collider2D>();
    }

    void FixedUpdate()
    {
        HandleIsGrounded();
        HandleMovement();
        HandleFire();
    }

    void HandleIsGrounded()
    {
        Vector3 position = collider2D.bounds.center - new Vector3(0, collider2D.bounds.extents.y, 0);
        RaycastHit2D hit = Physics2D.Raycast(position, Vector2.down, 0.1f, LayerMask.GetMask("Ground"));
        Debug.DrawLine(position, position + Vector3.down * 0.1f, Color.red);
        isGrounded = hit.collider != null;
    }

    void HandleMovement()
    {
        Vector2 newVelocity = new(moveInput.x * moveSpeed, rigidbody2D.velocity.y);
        rigidbody2D.velocity = newVelocity;
    }

    public void Move(InputValue inputValue)
    {
        moveInput = inputValue.Get<Vector2>();
    }

    public void Jump()
    {
        if (isGrounded)
            rigidbody2D.AddForce(Vector2.up * 20f, ForceMode2D.Impulse);
    }

    // Fire

    void HandleFire()
    {
        fireTimer -= Time.deltaTime;
        if (fireTimer <= 0f)
        {
            Fire();
            fireTimer = fireCooldown;
        }
    }

    void Fire()
    {
        // Debug.Log("Firing!");
    }
}
