using PlayerCar.SidePoints;
using UnityEngine;


public class UpdateSizeBoxColliderAxisX : MonoBehaviour
{
    [SerializeField] private SidePointsCarPlayer _pointsCarPlayer;
    [SerializeField] private BoxCollider _collider;
    
    private void OnEnable()
    {
        EventManagerPlayerCar.EventUpdateSizeBoxColliderAndShadow += SetTheValueOfTheColliderSize;
    }
    
    private void OnDisable()
    {
        EventManagerPlayerCar.EventUpdateSizeBoxColliderAndShadow -= SetTheValueOfTheColliderSize;
    }

    private void SetTheValueOfTheColliderSize()
    {
        Vector3 colliderSize = _collider.size;

        ISidePoint left = _pointsCarPlayer.Left;
        ISidePoint right = _pointsCarPlayer.Right;

        float x = CalculateSidePoints.GetLengthBetweenTwoPointsOnSelectedAxisModule(new SubtractionAxisX(), left, right) / 100.0f;
        float y = colliderSize.y;
        float z = colliderSize.z;
        _collider.size = new Vector3(x, y, z);
    }
    
}