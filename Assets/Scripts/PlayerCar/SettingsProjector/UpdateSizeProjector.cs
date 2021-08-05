using UnityEngine;

[RequireComponent(typeof(CalculateSizeProjector))]
public class UpdateSizeProjector : MonoBehaviour
{
    [SerializeField] private Transform _projector;
    [SerializeField] private ParametersTwoPoints _parametersRightAndLeftPoints;
    [SerializeField] private ParametersTwoPoints _parametersUpAndDownPoints;
    [SerializeField] private ParametersTwoPoints _parametersForwardAndBehindPoints;
    private CalculateSizeProjector _calculateSizeProjector;

    private void OnEnable()
    {
        EventManagerPlayerCar.EventUpdateSizeProjector += SetSizeProjector;
    }

    private void OnDisable()
    {
        EventManagerPlayerCar.EventUpdateSizeProjector -= SetSizeProjector;
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
        float z = GetSizeProjectorForwardAndBehindPointsZ();
        _projector.localScale = new Vector3(x, y, z);
    }

    private float GetSizeProjectorRightAndLeftPointsX()
    {
        Vector3 right = _parametersRightAndLeftPoints.PointOne.position;
        Vector3 left = _parametersRightAndLeftPoints.PointTwo.position;
        Axis axis = _parametersRightAndLeftPoints.Axis;

        return _calculateSizeProjector.GetSizeProjectorSelectedAxes(right, left, axis);
    }
    
    private float GetSizeProjectorUpAndDownPointsY()
    {
        Vector3 up = _parametersUpAndDownPoints.PointOne.position;
        Vector3 down = _parametersUpAndDownPoints.PointTwo.position;
        Axis axis = _parametersUpAndDownPoints.Axis;

        return _calculateSizeProjector.GetSizeProjectorSelectedAxes(up, down, axis);
    }
    
    private float GetSizeProjectorForwardAndBehindPointsZ()
    {
        Vector3 forward = _parametersForwardAndBehindPoints.PointOne.position;
        Vector3 behind = _parametersForwardAndBehindPoints.PointTwo.position;
        Axis axis = _parametersForwardAndBehindPoints.Axis;

        return _calculateSizeProjector.GetSizeProjectorSelectedAxes(forward, behind, axis);
    }
}
