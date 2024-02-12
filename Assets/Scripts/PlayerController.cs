using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField, Tooltip("The player's movement speed in units per second.")]
    private float _movementSpeed = 5f;
    [SerializeField, Tooltip("The player's angular rotation speed in degrees per second.")]
    private float _rotationSpeed = 500f;

    private Rigidbody2D _rigidBody = null;
    private Vector2 _targetVector = Vector2.zero;
    private Vector2 _movementVector = Vector2.zero;
    private Vector2 _velocity = Vector2.zero;

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    // Frame-rate independent. Used for physics calculations.
    void FixedUpdate()
    {
        // Gradually changes a vector towards a desired target over time.
        // Used to smooth player movement to avoid abrupt, jittery movement.
        _movementVector = Vector2.SmoothDamp(_movementVector, _targetVector, ref _velocity, 0.1f);
        _rigidBody.velocity = _movementVector * _movementSpeed; // Set the linear velocity of the player in units per second.

        if (_movementVector != Vector2.zero) // Avoid rotating the player to an upward resting position when not moving.
        {
            Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, _movementVector);
            // Gradually rotate the player towards the direction of movement.
            // Used to smooth player rotation to avoid abrupt, snappy turns.
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime); // Set the player's rotation.
        }
    }

    // Unity sends a message to this function whenever it detects input from anything bound to the "Move" action.
    // Grab the target vector from the input value and store it for use in fixed update.
    private void OnMove(InputValue movementValue)
    {
        _targetVector = movementValue.Get<Vector2>();
    }
}
