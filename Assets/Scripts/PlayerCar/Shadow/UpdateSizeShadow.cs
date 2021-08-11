using UnityEngine;

public class UpdateSizeShadow : MonoBehaviour
{
    [SerializeField] private ParametersTwoPoints _parametersRightAndLeftPoints;
    private Transform _thisTransform;

    private void OnEnable()
    {
        EventManagerPlayerCar.EventUpdateSizeBoxColliderAndShadow += SetSizeShadow;
    }

    private void OnDisable()
    {
        EventManagerPlayerCar.EventUpdateSizeBoxColliderAndShadow -= SetSizeShadow;
    }

    private void Start()
    {
        _thisTransform = transform;
        SetSizeShadow();
    }

    private void SetSizeShadow()
    {
        Vector3 scale = _thisTransform.localScale;
        float x = GetSizeProjectorRightAndLeftPointsX();
        float y = scale.y;
        float z = scale.z;
        _thisTransform.localScale = new Vector3(x, y, z);
    }
    
    private float GetSizeProjectorRightAndLeftPointsX()
    {
        Vector3 right = _parametersRightAndLeftPoints.PointOne.position;
        Vector3 left = _parametersRightAndLeftPoints.PointTwo.position;
        SubtractionAxis subtractionAxisX = new SubtractionAxisX();

        return CalculateTwoPoints.GetLengthBetweenTwoPointsOnSelectedAxis(subtractionAxisX, right, left);
    }
}
