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

    public void Move(InputValue inputValue)
    {
        Debug.Log("OnMoveBuilder input received");
        moveInput = inputValue.Get<Vector2>();
    }

    public void Jump()
    {
        rigidbody2D.AddForce(Vector2.up * 20f, ForceMode2D.Impulse);
    }
}
