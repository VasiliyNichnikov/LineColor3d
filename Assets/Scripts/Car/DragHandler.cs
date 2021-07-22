using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    [SerializeField] private Camera _camera;
    [SerializeField] private bool _movementOnTwoAxes;
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
        _pointStart = _camera.ScreenToViewportPoint(Input.mousePosition);
    }


    public void OnDrag(PointerEventData eventData)
    {
        _pointEnd = _camera.ScreenToViewportPoint(Input.mousePosition);

        if (_pointEnd == Vector3.zero || _pointStart == Vector3.zero) return;
        Vector3 dictionary = _pointEnd - _pointStart;
        _timeX = _timeSaveX + dictionary.x;
        _timeY = _timeSaveY + dictionary.y;

        if (_movementOnTwoAxes)
        {
            _timeX = _timeSaveY + dictionary.y;
        }
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
        EventManager.CallSelectingAnimationCar(AnimationsType.Width, _timeX);
        EventManager.CallSelectingAnimationCar(AnimationsType.Height, _timeY);
    }
}