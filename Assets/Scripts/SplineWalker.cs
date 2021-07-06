using UnityEngine;

public class SplineWalker : MonoBehaviour
{
    [SerializeField] private BezierSpline _spline;
    [SerializeField] private float _duration;
    private float _progress;
    private Transform _thisTransform;

    private void Start()
    {
        _thisTransform = transform;
    }

    private void Update()
    {
        _progress += Time.deltaTime / _duration;
        if (_progress > 1f)
        {
            _progress = 1f;
        }
        _thisTransform.localPosition = _spline.GetPoint(_progress);
    }
}
