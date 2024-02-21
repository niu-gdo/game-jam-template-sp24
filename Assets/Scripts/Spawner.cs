using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField, Tooltip("A game object to spawn.")]
    private GameObject _prefab;

    [SerializeField, Tooltip("Number of seconds between two consecutive spawns.")]
    private float _spawnInterval = 5f;

    [SerializeField, Tooltip("The number of degrees on either side of the Y (green) axis to randomly spawn game objects between.")]
    private float _spawnDispersion = 30f;

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
            GameObject spawnedObject = Instantiate(_prefab, transform.position, transform.rotation);

            float dispersionAngle = Random.Range(-_spawnDispersion, _spawnDispersion); // Create a random offset angle
            spawnedObject.transform.Rotate(Vector3.forward, dispersionAngle);   // Apply rotation by created offset

            _spawnTimer = _spawnInterval; // Reset the timer.
            _isReadyToSpawn = false;
        }
    }
}