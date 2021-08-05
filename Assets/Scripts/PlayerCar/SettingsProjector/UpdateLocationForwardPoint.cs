using UnityEngine;

public class UpdateLocationForwardPoint : MonoBehaviour
{
    [SerializeField] private Transform _forwardPoint;
    [SerializeField] private SortArrayObjectsRoad _arrayObjectsRoad;
    private Vector3 _positionObject;
    private Transform _thisTransform;

    private void Start()
    {
        _thisTransform = transform;
        SetPositionObjectValueAndUpdateProjector();
    }
    
    
    private void Update()
    {
        if (_thisTransform.position.z >= _positionObject.z)
        {
            SetPositionObjectValueAndUpdateProjector();
        }
        EventManagerPlayerCar.CallUpdateSizeProjector();
    }

    private void SetPositionObjectValueAndUpdateProjector()
    {
        _positionObject = _arrayObjectsRoad.GetAndRemoveFirstElementPosition();
        _forwardPoint.position = _positionObject;
    }
    
}
