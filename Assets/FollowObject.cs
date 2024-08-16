using UnityEngine;

public class FollowObject : MonoBehaviour
{
    void Start()
    {
        Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = new Vector2(0.25f, 0);
    }
}
