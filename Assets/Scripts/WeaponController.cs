using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponController : MonoBehaviour
{
    [SerializeField]
    private GameObject _projectilePrefab = null;

    [SerializeField]
    private Transform _firePoint = null;

    [SerializeField]
    private float _fireRate = 0.33f;

    private float _fireTimer = 0f;
    private bool _isReadyToFire = false;
    private bool _isFireHeld = false;

    void Update()
    {
        if (_fireTimer > 0f)
        {
            _fireTimer -= Time.deltaTime;
        }

        _isReadyToFire = _fireTimer <= 0f;

        if (_isFireHeld && _isReadyToFire)
        {
            FireProjectle();
            _fireTimer = _fireRate;
            _isReadyToFire = false;
        }
    }

    private void OnFire(InputValue buttonValue)
    {
        _isFireHeld = buttonValue.isPressed;
    }

    private void FireProjectle()
    {
        Instantiate(_projectilePrefab, _firePoint.position, _firePoint.rotation);
    }
}
