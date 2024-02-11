using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    [SerializeField]
    private GameObject _prefab = null;

    [SerializeField]
    private float _spawnRate = 5f;

    [SerializeField]
    private float _spawnRadius = 30f;

    private float _spawnTimer = 0f;
    private bool _isReadyToSpawn = false;

    void Update()
    {
        if (_spawnTimer > 0f)
        {
            _spawnTimer -= Time.deltaTime;
        }

        _isReadyToSpawn = _spawnTimer <= 0f;

        if (_isReadyToSpawn)
        {
            Instantiate(_prefab, transform.position, Quaternion.AngleAxis(Random.Range(-_spawnRadius, _spawnRadius), transform.forward) * transform.rotation);
            _spawnTimer = _spawnRate;
            _isReadyToSpawn = false;
        }
    }
}
