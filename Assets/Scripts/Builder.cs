using UnityEngine;
using UnityEngine.InputSystem;

public class Builder : MonoBehaviour
{
    Vector2 moveInput;
    [SerializeField] float moveSpeed = 5f;

    new Rigidbody2D rigidbody2D;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 newVelocity = new(moveInput.x * moveSpeed, rigidbody2D.velocity.y);
        rigidbody2D.velocity = newVelocity;
    }

    void OnMove(InputValue inputValue)
    {
        Debug.Log("Move input received");
        moveInput = inputValue.Get<Vector2>();
    }
}
