using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 15f;
    [SerializeField] float lifeTime = 99f;
    [SerializeField] int damage = 4;

    new Rigidbody2D rigidbody2D;
    Enemy target;

    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifeTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        }
    }

    public void Init(Enemy target)
    {
        this.target = target;
        Vector2 direction = target.transform.position - transform.position;
        rigidbody2D.velocity = direction.normalized * speed;
    }
}
