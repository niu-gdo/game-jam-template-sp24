using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private float _movementSpeed = 2f;

    private Rigidbody2D _rigidbody = null;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        _rigidbody.velocity = transform.up * _movementSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>())
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
