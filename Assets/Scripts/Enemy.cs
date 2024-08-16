using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] int maxHealth;
    int health;
    public int damage = 10;
    Builder builder;

    void Start()
    {
        health = maxHealth;
        builder = FindObjectOfType<Builder>();
    }

    void FixedUpdate()
    {
        HandleMovement();
    }

    void HandleMovement()
    {
        // Chase builder
        Vector3 direction = builder.transform.position - transform.position;
        Vector3 normalizedDirection = direction.normalized;
        transform.position += moveSpeed * Time.fixedDeltaTime * normalizedDirection;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
            Destroy(gameObject);
    }
}
