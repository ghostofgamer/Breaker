using UnityEngine;
using Random = UnityEngine.Random;

public class WaveMotion : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _amplitude = 1f;

    private Vector3 _initialPosition;

    private void Start()
    {
        _initialPosition = transform.position;
        _amplitude = Random.Range(3f, 5f);
    }

    private void Update()
    {
        float z = Mathf.Sin(Time.time * _speed) * _amplitude;
        transform.position = new Vector3(_initialPosition.x, _initialPosition.y, _initialPosition.z + z);
    }
}
