using UnityEngine;

[RequireComponent(typeof(CalculateSizeBoxCollider))]
public class UpdateSizeBoxColliderAxesX : MonoBehaviour
{
    [SerializeField] private bool _configurePointsByMesh;
    [SerializeField] private BoxCollider _collider;
    [SerializeField] private ParametersTwoPoints _parametersRightAndLeftPoints;
    [SerializeField, InterfaceType(typeof(IProvideBordersObject))] private Object _provideBordersObject;
    private CalculateSizeBoxCollider _calculateSizeBoxCollider;
    private IProvideBordersObject _iProvideBorders => _provideBordersObject as IProvideBordersObject;
    
    
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
        _calculateSizeBoxCollider = GetComponent<CalculateSizeBoxCollider>();
        SetSizeColliderStart();
    }
    
    private void SetSizeColliderStart()
    {
        Vector3 colliderSize = _calculateSizeBoxCollider.GetSizeBoxCollider(_collider, _iProvideBorders);
        _collider.size = colliderSize;

        if (!_configurePointsByMesh) return;
        
        var (right, left) = _calculateSizeBoxCollider.GetPositionRigthAndLeftPointMeshCar(_iProvideBorders);
        _parametersRightAndLeftPoints.PointOne.position = right;
        _parametersRightAndLeftPoints.PointTwo.position = left;
    }

    private void UpdateSizeCollider()
    {
        Vector3 right = _parametersRightAndLeftPoints.PointOne.position;
        Vector3 left = _parametersRightAndLeftPoints.PointTwo.position;

        Vector3 colliderSize = _calculateSizeBoxCollider.GetSizeBoxCollider(_collider, right, left);
        _collider.size = colliderSize;
    }
}