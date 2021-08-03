using UnityEngine;

[RequireComponent(typeof(CalculateSizeBoxCollider))]
public class UpdateSizeBoxCollider : MonoBehaviour
{
    [SerializeField] private BoxCollider _collider;
    [SerializeField] private ParametersTwoPoints _parametersRightAndLeftPoints;
    private CalculateSizeBoxCollider _calculateSizeBoxCollider;

    private void OnEnable()
    {
        EventManagerPlayerCar.EventUpdateSizeBoxCollider += UpdateSizeCollider;
    }

    private void OnDisable()
    {
        EventManagerPlayerCar.EventUpdateSizeBoxCollider -= UpdateSizeCollider;
    }

    private void Start()
    {
        SetSizeColliderStart();
    }
    
    private void SetSizeColliderStart()
    {
        _calculateSizeBoxCollider = GetComponent<CalculateSizeBoxCollider>();
        Vector3 colliderSize = _calculateSizeBoxCollider.GetSizeBoxCollider(_collider);
        _collider.size = colliderSize;

        var points = _calculateSizeBoxCollider.GetPositionRigthAndLeftPointMeshCar();
        _parametersRightAndLeftPoints.PointOne.position = points.right;
        _parametersRightAndLeftPoints.PointTwo.position = points.left;
    }

    private void UpdateSizeCollider()
    {
        Vector3 right = _parametersRightAndLeftPoints.PointOne.position;
        Vector3 left = _parametersRightAndLeftPoints.PointTwo.position;

        Vector3 colliderSize = _calculateSizeBoxCollider.GetSizeBoxCollider(_collider, right, left);
        _collider.size = colliderSize;
    }
}