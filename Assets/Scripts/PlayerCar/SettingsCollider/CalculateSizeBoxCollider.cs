using UnityEngine;

public class CalculateSizeBoxCollider : MonoBehaviour
{
    [SerializeField] private ProvideBordersCar _provideBorders;

    public Vector3 GetSizeBoxCollider(BoxCollider collider)
    {
        Vector3 colliderSize = collider.size;
        
        Vector3 right = _provideBorders.GetPositionMeshPoint(SideMeshCar.Right);
        Vector3 left = _provideBorders.GetPositionMeshPoint(SideMeshCar.Left);

        float x = Mathf.Abs(right.x - left.x);
        return new Vector3(x, colliderSize.y, colliderSize.z);
    }
    
    public Vector3 GetSizeBoxCollider(BoxCollider collider, Vector3 right, Vector3 left)
    {
        Vector3 colliderSize = collider.size;

        right = _provideBorders.transform.InverseTransformPoint(right);
        left = _provideBorders.transform.InverseTransformPoint(left);

        float x = Mathf.Abs(right.x - left.x);
        return new Vector3(x, colliderSize.y, colliderSize.z);
    }

    public (Vector3 right, Vector3 left) GetPositionRigthAndLeftPointMeshCar()
    {
        Vector3 right = _provideBorders.GetPositionMeshPoint(SideMeshCar.Right);
        Vector3 left = _provideBorders.GetPositionMeshPoint(SideMeshCar.Left);
        right = _provideBorders.transform.TransformPoint(right);
        left = _provideBorders.transform.TransformPoint(left);
        return (right, left);
    }
    
}
