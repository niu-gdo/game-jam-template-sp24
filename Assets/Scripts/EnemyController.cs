using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField, Tooltip("The enemy's movement speed in units per second")]
    private float _movementSpeed = 2f;

    private Rigidbody2D _rigidbody = null;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        _rigidbody.velocity = transform.up * _movementSpeed; // Set the linear velocity of this enemy in units per second.
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // On collision with another game object, check if it's the player.
        // If so, destory it and this enemy.
        if (collision.GetComponent<PlayerController>())
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
