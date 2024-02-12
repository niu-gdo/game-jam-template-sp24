using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField, Tooltip("The projectile's movement speed in units per second")]
    private float _projectileSpeed = 10f;

    private Rigidbody2D _rigidbody = null;
    private Renderer _renderer = null;

    private void Start()
    {
        _renderer = GetComponentInChildren<Renderer>(); // Grab this projectile's sprite renderer from its child object.
        _rigidbody = GetComponent<Rigidbody2D>();

        _rigidbody.velocity = transform.up * _projectileSpeed; // Set the linear velocity of this projectile in units per second.
    }

    private void Update()
    {
        // Check if this projectile is not visible (i.e., off-screen) and destroy it if so.
        if (!_renderer.isVisible) 
        {
            Destroy(gameObject);
        }
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
