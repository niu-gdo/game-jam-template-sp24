using UnityEngine;

public class TimedDestroy : MonoBehaviour
{
    [SerializeField, Tooltip("Number of seconds after spawning that the object will destroy itself.")]
    private float _destroyTime = 6f;

    private float _spawnTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        _spawnTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > _spawnTime + _destroyTime)
            Destroy(gameObject);
    }
}