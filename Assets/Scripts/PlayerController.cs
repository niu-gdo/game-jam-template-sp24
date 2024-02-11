using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _movementSpeed = 5f;
    [SerializeField]
    private float _rotationSpeed = 500f;

    private Rigidbody2D _rigidBody = null;
    private Vector2 _targetVector = Vector2.zero;
    private Vector2 _movementVector = Vector2.zero;
    private Vector2 _velocity = Vector2.zero;

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        _movementVector = Vector2.SmoothDamp(_movementVector, _targetVector, ref _velocity, 0.1f);
        _rigidBody.velocity = _movementVector * _movementSpeed;

        if (_movementVector != Vector2.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, _movementVector);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
        }
    }
    private void OnMove(InputValue movementValue)
    {
        _targetVector = movementValue.Get<Vector2>();
    }
}
