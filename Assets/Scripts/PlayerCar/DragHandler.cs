using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    [SerializeField] private Camera _camera;
    [SerializeField, Range(1, 10)] private float _sensitivity;

    private Vector3 _pointStart;
    private Vector3 _pointEnd;

    private float _timeSaveX, _timeSaveY;
    private float _timeX, _timeY;

    private void Start()
    {
        _timeX = 0.0f;
        _timeY = 0.0f;
        _timeSaveX = _timeX;
        _timeSaveY = _timeY;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _pointStart = Input.mousePosition;
        _pointStart.z = 0f;
    }


    public void OnDrag(PointerEventData eventData)
    {
        _pointEnd = Input.mousePosition;
        _pointEnd.z = 0f;

        Vector3 direction = (_pointEnd - _pointStart) * _sensitivity;
        direction = _camera.ScreenToViewportPoint(direction);
        
        _timeX = Mathf.Clamp01(_timeSaveX + direction.x);
        _timeY = Mathf.Clamp01(_timeSaveY + direction.y);
        EventManagerPlayerCar.CallUpdateSizeBoxCollider();
        EventManagerPlayerCar.CallUpdateSizeProjector();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _timeSaveX = _timeX;    
        _timeSaveY = _timeY;
        _pointStart = Vector3.zero;
        _pointEnd = Vector3.zero;
    }

    private void Update()
    {
        EventManagerPlayerCar.CallSelectingAnimationCar(AnimationsType.Width, _timeX);
        EventManagerPlayerCar.CallSelectingAnimationCar(AnimationsType.Height, _timeY);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawLine(_pointStart, _pointEnd);
    }
}