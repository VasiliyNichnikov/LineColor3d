using UnityEngine;

public class DetectionClick : MonoBehaviour
{
    [HideInInspector] public Vector2 MousePositionDown;
    [HideInInspector] public Vector2 MousePositionDrag;

    public Camera Camera
    {
        get => _camera;
        set
        {
            if (_camera == null)
                _camera = value;
        }
    }

    public float Sensitivity
    {
        get => _sensitivity;
        set
        {
            if (value >= 1 && value <= 10)
                _sensitivity = value;
        }
    }
    
    [SerializeField] private Camera _camera;
    [SerializeField, Range(1, 10)] private float _sensitivity;
    
    public Vector2 GetDirection()
    {
        Vector2 direction = (MousePositionDrag - MousePositionDown) * _sensitivity;
        return _camera.ScreenToViewportPoint(direction);
    }

    public void ResetingMousePositionDownAndMousePositionDrag()
    {
        MousePositionDown = Vector2.zero;
        MousePositionDrag = Vector2.zero;
    }
    
}
