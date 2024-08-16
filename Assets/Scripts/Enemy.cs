using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    public int damage = 10;
    Builder builder;

    void Start()
    {
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
}
