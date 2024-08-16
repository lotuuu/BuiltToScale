using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Turret : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    Vector2 moveInput;

    new Rigidbody2D rigidbody2D;
    new Collider2D collider2D;
    EnemiesTracker enemiesTracker;

    bool isGrounded = true;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        collider2D = GetComponent<BoxCollider2D>();
        enemiesTracker = FindObjectOfType<EnemiesTracker>();
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

    [SerializeField] float fireCooldown = 2f;
    [SerializeField] GameObject bulletPrefab;
    float fireTimer = 0f;

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
        Enemy target = FindNearestEnemy();
        if (target == null)
            return;

        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        Bullet bulletComponent = bullet.GetComponent<Bullet>();
        bulletComponent.Init(target);
    }

    Enemy FindNearestEnemy()
    {
        List<Enemy> enemies = enemiesTracker.Enemies;

        Enemy nearestEnemy = null;
        float nearestDistance = Mathf.Infinity;
        foreach (Enemy enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                nearestEnemy = enemy;
            }
        }
        return nearestEnemy;
    }
}
