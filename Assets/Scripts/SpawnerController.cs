using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    [SerializeField, Tooltip("A game object to spawn.")]
    private GameObject _prefab = null;

    [SerializeField, Tooltip("How frequently to spawn game objects in seconds.")]
    private float _spawnRate = 5f;

    [SerializeField, Tooltip("The number of degrees on either side of the Y (green) axis to randomly spawn game objects between.")]
    private float _spawnRadius = 30f;

    private float _spawnTimer = 0f;
    private bool _isReadyToSpawn = false;

    void Update()
    {
        // A simple timer that works by subtracting the time between updates, or frames,
        // from the timer variable, counting down from whatever the spawn rate is.
        if (_spawnTimer > 0f)
        {
            _spawnTimer -= Time.deltaTime;
        }

        _isReadyToSpawn = _spawnTimer <= 0f; // Once the timer counts down to zero, the game object is ready to spawn.

        if (_isReadyToSpawn)
        {
            // Randomly create a game object between the specified spawn radius.
            Instantiate(_prefab, transform.position, Quaternion.AngleAxis(Random.Range(-_spawnRadius, _spawnRadius), transform.forward) * transform.rotation);
            _spawnTimer = _spawnRate; // Reset the timer.
            _isReadyToSpawn = false;
        }
    }
}
