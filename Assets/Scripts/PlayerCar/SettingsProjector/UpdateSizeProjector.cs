using PlayerCar.SidePoints;
using UnityEngine;

public class UpdateSizeProjector : MonoBehaviour
{
    [SerializeField] private SidePointsCarPlayer _pointsCarPlayer;
    [SerializeField] private Transform _projector;


    private void OnEnable()
    {
        EventManagerPlayerCar.EventUpdateSizeProjector += SetTheValueOfTheTransformProjectorSize;
    }

    private void OnDisable()
    {
        EventManagerPlayerCar.EventUpdateSizeProjector -= SetTheValueOfTheTransformProjectorSize;
    }


    private void SetTheValueOfTheTransformProjectorSize()
    {
        float x = CalculateSidePoints.GetLengthBetweenTwoPointsOnSelectedAxisModule(new SubtractionAxisX(),
            _pointsCarPlayer.Left, _pointsCarPlayer.Right);
        float y = CalculateSidePoints.GetLengthBetweenTwoPointsOnSelectedAxisModule(new SubtractionAxisY(),
            _pointsCarPlayer.Up, _pointsCarPlayer.Down);
        float z = CalculateSidePoints.GetLengthBetweenTwoPointsOnSelectedAxisModule(new SubtractionAxisZ(),
            _pointsCarPlayer.ForwardProjector, _pointsCarPlayer.BehindProjector);
        _projector.localScale = new Vector3(x, y, z);
    }
}