using UnityEngine;
using UnityEngine.InputSystem;

public class Builder : MonoBehaviour
{
    Vector2 moveInput;
    [SerializeField] float moveSpeed = 5f;

    new Rigidbody2D rigidbody2D;
    new Collider2D collider2D;
    SpriteRenderer spriteRenderer;
    bool isGrounded = true;


    void Start()
    {
        health = maxHealth;
        rigidbody2D = GetComponent<Rigidbody2D>();
        collider2D = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        baseColor = spriteRenderer.color;
    }

    void FixedUpdate()
    {
        HandleImmunity();
        HandleIsGrounded();
        HandleMovement();
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

    // Health

    [SerializeField] int maxHealth = 100;
    int health;

    [SerializeField] float immunityDuration = 1f;
    float immunityTimer = 0f;
    bool isImmune;

    Color baseColor;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            ReceiveDamage(enemy.damage);
            if (health <= 0)
            {
                Debug.Log("Died");
            }
        }
    }

    void ReceiveDamage(int damage)
    {
        if (isImmune)
            return;

        health -= damage;
        isImmune = true;
        immunityTimer = immunityDuration;
        spriteRenderer.color = new Color(1, 0, 0, 0.5f);
    }

    void HandleImmunity()
    {
        if (isImmune)
        {
            immunityTimer -= Time.deltaTime;
            if (immunityTimer <= 0f)
            {
                isImmune = false;
                spriteRenderer.color = baseColor;
            }
        }
    }
}
