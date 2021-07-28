using System;
using UnityEngine;

public class CalculateAndUpdateBoxCollider : MonoBehaviour
{
    [SerializeField] private ProvideBordersCar _provideBorders;
    [SerializeField] private BoxCollider _collider;
    [SerializeField] private ParametersLeftAndRightPoints _parametersTwoPoints;

    private void OnEnable()
    {
        EventManager.EventUpdateSizeBoxCollider += UpdateSizeCollider;
    }

    private void OnDisable()
    {
        EventManager.EventUpdateSizeBoxCollider -= UpdateSizeCollider;
    }

    private void Start()
    {
        (Vector3 right, Vector3 left) points = ChangeSizeBoxCollider();
        UpdatePositionPoints(points.right, points.left);
    }

    private (Vector3 right, Vector3 left) ChangeSizeBoxCollider(bool mesh=true)
    {
        Vector3 colliderSize = _collider.size;
        
        float x = colliderSize.x;
        float y = colliderSize.y;
        float z = colliderSize.z;

        Vector3 right, left;
        
        if (mesh)
        {
            right = _provideBorders.GetPositionMeshPoint(SideMeshCar.Right);
            left = _provideBorders.GetPositionMeshPoint(SideMeshCar.Left);
        }
        else
        {
            right = _parametersTwoPoints.Right.position;
            left = _parametersTwoPoints.Left.position;

            right = _provideBorders.transform.InverseTransformPoint(right);
            left = _provideBorders.transform.InverseTransformPoint(left);
        }

        switch (_parametersTwoPoints.Axis)
        {
            case Axis.X:
                x = Mathf.Abs(left.x - right.x);
                break;
            
            case Axis.Y:
                y = Mathf.Abs(left.y - right.y);
                break;
            
            case Axis.Z:
                z = Mathf.Abs(left.z - right.z);
                break;
            
            default:
                throw new ArgumentOutOfRangeException();
        }
        _collider.size = new Vector3(x, y, z);

        return (right, left);
    }
    
    private void UpdatePositionPoints(Vector3 right, Vector3 left)
    {
        right = _provideBorders.transform.TransformPoint(right);
        left = _provideBorders.transform.TransformPoint(left);
        
        _parametersTwoPoints.Right.position = right;
        _parametersTwoPoints.Left.position = left;
    }
    
    private void UpdateSizeCollider()
    {
        ChangeSizeBoxCollider(false);
    }
}
