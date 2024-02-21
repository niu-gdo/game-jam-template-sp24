using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField, Tooltip("The player's movement speed in units per second.")]
    private float _movementSpeed = 5f;

    [SerializeField, Tooltip("Amount of smoothing time applied to velocity changes")]
    private float _movementSmoothingTime = 0.1f;

    [SerializeField, Tooltip("The player's angular rotation speed in degrees per second.")]
    private float _rotationSpeed = 500f;

    private Rigidbody2D _rigidbody;
    private Vector2 _movementInput = Vector2.zero;
    private Vector2 _currentMovement = Vector2.zero;
    private Vector2 _movementSmoothingVelocity = Vector2.zero;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Frame-rate independent. Used for physics calculations.
    void FixedUpdate()
    {
        // Gradually changes a vector towards a desired target over time.
        // Used to smooth player movement to avoid abrupt, jittery movement.
        _currentMovement = Vector2.SmoothDamp(
            _currentMovement,                   // Our current velocity
            _movementInput,                     // The player's input, we want to *reach* this
            ref _movementSmoothingVelocity,     // our current *acceleration*
            _movementSmoothingTime              // smoothing duration, lower is faster.
        );
        _rigidbody.velocity = _currentMovement * _movementSpeed; // Set the linear velocity of the player in units per second.

        if (_movementInput != Vector2.zero) // Avoid rotating the player to an upward resting position when not moving.
        {
            Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, _currentMovement);

            // Gradually rotate the player towards the direction of movement.
            // Used to smooth player rotation to avoid abrupt, snappy turns.
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed * Time.fixedDeltaTime); // Set the player's rotation.
        }
    }

    // Unity sends a message to this function whenever it detects input from anything bound to the "Move" action.
    // Grab the target vector from the input value and store it for use in fixed update.
    private void OnMove(InputValue movementValue)
    {
        _movementInput = movementValue.Get<Vector2>();
    }
}