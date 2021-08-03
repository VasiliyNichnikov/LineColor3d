using UnityEngine;

[RequireComponent(typeof(CalculateSizeProjector))]
public class UpdateSizeProjector : MonoBehaviour
{
    [SerializeField] private Transform _projector;
    [SerializeField] private ParametersTwoPoints _parametersRightAndLeftPoints;
    [SerializeField] private ParametersTwoPoints _parametersUpAndDownPoints;
    private CalculateSizeProjector _calculateSizeProjector;
    
    private void OnEnable()
    {
        EventManagerPlayerCar.EventUpdateSizeBoxCollider += SetSizeProjector;
    }

    private void OnDisable()
    {
        EventManagerPlayerCar.EventUpdateSizeBoxCollider -= SetSizeProjector;
    }
    
    private void Start()
    {
        _calculateSizeProjector = GetComponent<CalculateSizeProjector>();
        SetSizeProjector();
    }

    private void SetSizeProjector()
    {
        float x = GetSizeProjectorRightAndLeftPointsX();
        float y = GetSizeProjectorUpAndDownPointsY();
        float z = _projector.localScale.z;
        
        _projector.localScale = new Vector3(x, y, z);
    }

    private float GetSizeProjectorRightAndLeftPointsX()
    {
        Vector3 right = _parametersRightAndLeftPoints.PointOne.position;
        Vector3 left = _parametersRightAndLeftPoints.PointTwo.position;
        Axis axis = _parametersRightAndLeftPoints.Axis;

        return _calculateSizeProjector.GetSizeProjectorSelectedAxes(_projector, right, left, axis);
    }
    
    private float GetSizeProjectorUpAndDownPointsY()
    {
        Vector3 up = _parametersUpAndDownPoints.PointOne.position;
        Vector3 down = _parametersUpAndDownPoints.PointTwo.position;
        Axis axis = _parametersUpAndDownPoints.Axis;

        return _calculateSizeProjector.GetSizeProjectorSelectedAxes(_projector, up, down, axis);
    }
}
