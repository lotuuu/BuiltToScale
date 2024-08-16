using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] int maxHealth;
    int health;
    public int damage = 10;
    Builder builder;

    public static event System.Action<Enemy> OnEnemySpawned;
    public static event System.Action<Enemy> OnEnemyDestroyed;

    void Start()
    {
        health = maxHealth;
        builder = FindObjectOfType<Builder>();
        OnEnemySpawned?.Invoke(this);
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
        Debug.Log("Enemy took damage: " + damage);
        health -= damage;
        Debug.Log("Enemy health: " + health);
        if (health <= 0)
        {
            OnEnemyDestroyed?.Invoke(this);
            Destroy(gameObject);
        }
    }
}
