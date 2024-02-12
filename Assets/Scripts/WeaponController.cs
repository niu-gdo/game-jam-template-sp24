using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponController : MonoBehaviour
{
    [SerializeField, Tooltip("A game object to use as a projectile.")]
    private GameObject _projectilePrefab = null;

    [SerializeField, Tooltip("Where to shoot projectiles from.")]
    private Transform _firePoint = null;

    [SerializeField, Tooltip("How frequently to shoot projectiles in seconds.")]
    private float _fireRate = 0.33f;

    private float _fireTimer = 0f;
    private bool _isReadyToFire = false;
    private bool _isFireHeld = false;

    void Update()
    {
        // A simple timer that works by subtracting the time between updates, or frames,
        // from the timer variable, counting down from whatever the fire rate is.
        if (_fireTimer > 0f)
        {
            _fireTimer -= Time.deltaTime;
        }

        _isReadyToFire = _fireTimer <= 0f; // Once the timer counts down to zero, the projectile is ready to fire.

        if (_isFireHeld && _isReadyToFire)
        {
            FireProjectle(); // Create a projectile object.
            _fireTimer = _fireRate; // Reset the timer.
            _isReadyToFire = false;
        }
    }

    // Unity sends a message to this function whenever the player presses or releases something bound to the "Fire" action.
    // Store whether or not input's pressed to use in update.
    private void OnFire(InputValue buttonValue)
    {
        _isFireHeld = buttonValue.isPressed;
    }

    // Create a projectile object at the fire point's current position and rotation.
    private void FireProjectle()
    {
        Instantiate(_projectilePrefab, _firePoint.position, _firePoint.rotation);
    }
}
