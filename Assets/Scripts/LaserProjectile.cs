using UnityEngine;

public class LaserProjectile : MonoBehaviour
{
    [SerializeField, Tooltip("The projectile's movement speed in units per second")]
    private float _projectileSpeed = 10f;

    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        _rigidbody.velocity = transform.up * _projectileSpeed; // Set the linear velocity of this projectile in units per second.
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // On collision with another game object, check if it's an enemy.
        // If so, destory it and this projectile.
        if (collision.GetComponent<EnemyController>())
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}