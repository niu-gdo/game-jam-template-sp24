using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Device;

public class ProjectileController : MonoBehaviour
{
    [SerializeField]
    private float _projectileSpeed = 10f;

    private Rigidbody2D _rigidbody = null;
    private Renderer _renderer = null;

    private void Start()
    {
        _renderer = GetComponentInChildren<Renderer>();
        _rigidbody = GetComponent<Rigidbody2D>();

        _rigidbody.velocity = transform.up * _projectileSpeed;
    }

    private void Update()
    {
        if (!_renderer.isVisible) 
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<EnemyController>())
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
