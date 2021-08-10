using UnityEngine;

public class UpdateSizeProjector : MonoBehaviour
{
    [SerializeField] private Transform _projector;
    [SerializeField] private ParametersTwoPoints _parametersRightAndLeftPoints;
    [SerializeField] private ParametersTwoPoints _parametersUpAndDownPoints;
    [SerializeField] private ParametersTwoPoints _parametersForwardAndBehindPoints;

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
        SubtractionAxis subtractionAxisX = new SubtractionAxisX();

        return CalculateTwoPoints.GetLengthBetweenTwoPointsOnSelectedAxis(subtractionAxisX, right, left);
    }
    
    private float GetSizeProjectorUpAndDownPointsY()
    {
        Vector3 up = _parametersUpAndDownPoints.PointOne.position;
        Vector3 down = _parametersUpAndDownPoints.PointTwo.position;
        SubtractionAxis subtractionAxisY = new SubtractionAxisY();

        return CalculateTwoPoints.GetLengthBetweenTwoPointsOnSelectedAxis(subtractionAxisY, up, down);
    }
    
    private float GetSizeProjectorForwardAndBehindPointsZ()
    {
        Vector3 forward = _parametersForwardAndBehindPoints.PointOne.position;
        Vector3 behind = _parametersForwardAndBehindPoints.PointTwo.position;
        SubtractionAxis subtractionAxisZ = new SubtractionAxisZ();

        return CalculateTwoPoints.GetLengthBetweenTwoPointsOnSelectedAxis(subtractionAxisZ, forward, behind);
    }
}
