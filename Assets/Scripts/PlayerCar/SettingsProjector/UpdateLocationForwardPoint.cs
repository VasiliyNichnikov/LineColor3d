using UnityEngine;

public class UpdateLocationForwardPoint : MonoBehaviour
{
    [SerializeField, Range(0, 300)] private float _maxDistance;
    [SerializeField] private GameObject _projector;
    [SerializeField] private Transform _forwardPoint;
    [SerializeField] private ArrayObjectsRoad _arrayObjectsRoad;
    private Vector3 _positionObstacle;
    private Transform _thisTransform;

    private void Start()
    {
        _thisTransform = transform;
        SetPositionObjectValueAndUpdateProjector();
    }
    
    
    private void Update()
    {
        if (_thisTransform.position.z >= _positionObstacle.z)
        {
            SetPositionObjectValueAndUpdateProjector();
        }

        float distance = Vector3.Distance(_thisTransform.position, _positionObstacle);
        if (distance <= _maxDistance)
        {
            _projector.SetActive(true);
            EventManagerPlayerCar.CallUpdateSizeProjector();    
        }
        else
        {
            _projector.SetActive(false);
        }
    }

    private void SetPositionObjectValueAndUpdateProjector()
    {
        _positionObstacle = _arrayObjectsRoad.GetAndRemoveFirstElementPosition();
        _forwardPoint.position = _positionObstacle;
    }
    
}
