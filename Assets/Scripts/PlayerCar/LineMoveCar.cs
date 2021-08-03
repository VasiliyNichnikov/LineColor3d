using UnityEngine;

public class LineMoveCar : MonoBehaviour
{
    public Vector3 StartPosition;
    public Vector3 EndPosition;

    [SerializeField, Range(0, 15)] private float _speed;
    private Transform _thisTransorm;

    public float Speed => _speed;

    private void Start()
    {
        _thisTransorm = transform;
        _thisTransorm.position = StartPosition;
    }

    private void Update()
    {
        _thisTransorm.position = Vector3.MoveTowards(_thisTransorm.position, EndPosition, _speed * Time.deltaTime);
    }
}
