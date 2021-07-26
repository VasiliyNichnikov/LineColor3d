using UnityEngine;

public class StartSizeBoxColliderCar : MonoBehaviour
{
    [SerializeField] private CalculatorBoxColliderCarBody _calculatorBoxCollider;

    private BoxCollider _collider;

    private void Start()
    {
        _collider = GetComponent<BoxCollider>();
        CalculateInitialSizeCollider();
    }

    private void CalculateInitialSizeCollider()
    {
        Vector3 up = _calculatorBoxCollider.GetPositionPointMesh(SideCar.Up);
        Vector3 down = _calculatorBoxCollider.GetPositionPointFromArrayPoints(SideCar.Down);
        
        Vector3 left = _calculatorBoxCollider.GetPositionPointMesh(SideCar.Left);
        Vector3 right = _calculatorBoxCollider.GetPositionPointMesh(SideCar.Right);

        Vector3 forward = _calculatorBoxCollider.GetPositionPointMesh(SideCar.Forward);
        Vector3 behind = _calculatorBoxCollider.GetPositionPointMesh(SideCar.Behind);
        
        _collider.size = new Vector3(Mathf.Abs(left.x - right.x), Mathf.Abs(down.y - up.y), Mathf.Abs(behind.z - forward.z));
        
        SetTransormPoint(SideCar.Up, up);
        SetTransormPoint(SideCar.Right, right);
        SetTransormPoint(SideCar.Left, left);
    }

    private void SetTransormPoint(SideCar side, Vector3 point)
    {
        Transform selectedTransform = _calculatorBoxCollider.GetTransformPointFromArrayPoints(side);
        selectedTransform.position = transform.TransformPoint(point);
    }
}
