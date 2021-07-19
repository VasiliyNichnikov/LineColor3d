using UnityEngine;

public class SplineWalker : MonoBehaviour
{
    [SerializeField] private Spline _spline;
    [SerializeField] private float _spacing;
    [SerializeField] private float _speed;
    private Vector2[] _points;
    private int _index;
    private Transform _thisTransform;

    private void Start()
    {
        _thisTransform = transform;
        _points = CalculatePoints.GetEventlySpacedPoints(_spline, _spacing);
        _thisTransform.position = new Vector3(_points[0].x, _thisTransform.position.y, _points[0].y);
    }

    private void Update()
    {
        if (_index < _points.Length)
        {
            Vector3 point = new Vector3(_points[_index].x, 0, _points[_index].y);
            _thisTransform.position =
                Vector3.MoveTowards(_thisTransform.position, point, _speed * Time.deltaTime);
            
            Vector3 targetDir = point - _thisTransform.position;
            Vector3 newDir = Vector3.RotateTowards(_thisTransform.forward, targetDir, _speed * Time.deltaTime, 0.0f);
            _thisTransform.rotation = Quaternion.LookRotation(newDir);
            
            if (_thisTransform.position == point)
            {
                _index++;
            }
        }
    }
}
