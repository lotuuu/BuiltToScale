using UnityEngine;
using UnityEngine.InputSystem;

public class Turret : MonoBehaviour
{
    Vector2 moveInput;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float fireCooldown = 5f;

    new Rigidbody2D rigidbody2D;

    float fireTimer = 0f;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        HandleMovement();
        HandleFire();
    }

    void HandleMovement()
    {
        Vector2 newVelocity = new(moveInput.x * moveSpeed, rigidbody2D.velocity.y);
        rigidbody2D.velocity = newVelocity;
    }

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
        Debug.Log("Firing!");
    }

    void OnMove(InputValue inputValue)
    {
        Debug.Log("Move input received");
        moveInput = inputValue.Get<Vector2>();
    }
}
