using UnityEngine;

public class RejectionAnimationCar : MonoBehaviour
{
    [SerializeField] private DragHandler _drag;
    [SerializeField, Range(0, 15)] private float _stepZ;
    private Transform _thisTransform;
    private const float _timeAnimation = 0.5f;

    private void Start()
    {
        _thisTransform = transform;
    }

    public void ResettingHeightAndWidthAnimation()
    {
        CalculatorTimeAnimation calculatorTime = _drag.TimeAnimation;
        DetectionClick detectionClick = _drag.DetectionClick;
        
        Vector2 direction = new Vector2(calculatorTime.SaveTimeX - _timeAnimation,
            _timeAnimation - calculatorTime.SaveTimeY);
        calculatorTime.ChangingValuesTimeXAndTimeY(direction);
        detectionClick.ResetingMousePositionDownAndMousePositionDrag();
        calculatorTime.ResetingSaveTimeXAndSaveTimeY();
        GameOver.OffCrashed();
    }

    public void DepartureBack()
    {
        Vector3 position = _thisTransform.position;
        _thisTransform.position = new Vector3(position.x, position.y, position.z - _stepZ);
    }
    
}
