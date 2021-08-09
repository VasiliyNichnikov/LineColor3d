using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(DetectionClick))]
public class DragHandler : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    private CalculatorTimeAnimation _timeAnimation;
    private DetectionClick _detectionClick;

    private void Start()
    {
        _timeAnimation = new CalculatorTimeAnimation();
        _detectionClick = GetComponent<DetectionClick>();
        _timeAnimation.ResetingSaveTimeXAndSaveTimeY();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _detectionClick.MousePositionDown = eventData.position;
    }
    
    public void OnDrag(PointerEventData eventData)
    {
        _detectionClick.MousePositionDrag = eventData.position;
        
        Vector2 direction = _detectionClick.GetDirection();
        _timeAnimation.ChangingValuesTimeXAndTimeY(direction);
        UpdateSizeBoxColliderAndProjector();
    }
    
    private static void UpdateSizeBoxColliderAndProjector()
    {
        EventManagerPlayerCar.CallUpdateSizeBoxCollider();
        EventManagerPlayerCar.CallUpdateSizeProjector();
    }
    
    public void OnPointerUp(PointerEventData eventData)
    {
        RessetingParameters();
    }

    private void RessetingParameters()
    {
        _timeAnimation.ResetingSaveTimeXAndSaveTimeY();
        _detectionClick.ResetingMousePositionDownAndMousePositionDrag();
    }
    
    private void Update()
    {
        EventManagerPlayerCar.CallSelectingAnimationCar(AnimationsType.Width, _timeAnimation.TimeX);
        EventManagerPlayerCar.CallSelectingAnimationCar(AnimationsType.Height, _timeAnimation.TimeY);
    }
}