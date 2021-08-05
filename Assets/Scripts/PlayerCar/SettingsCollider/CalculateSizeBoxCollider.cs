using UnityEngine;

public class CalculateSizeBoxCollider : MonoBehaviour
{
    [SerializeField] private ProvideBordersObject _provideBorders;

    public Vector3 GetSizeBoxCollider(BoxCollider boxCollider)
    {
        Vector3 colliderSize = boxCollider.size;
        
        Vector3 right = _provideBorders.GetPositionMeshPoint(SideMeshObject.Right);
        Vector3 left = _provideBorders.GetPositionMeshPoint(SideMeshObject.Left);

        float x = Mathf.Abs(right.x - left.x);
        return new Vector3(x, colliderSize.y, colliderSize.z);
    }
    
    public Vector3 GetSizeBoxCollider(BoxCollider boxCollider, Vector3 right, Vector3 left)
    {
        Vector3 colliderSize = boxCollider.size;

        right = _provideBorders.transform.InverseTransformPoint(right);
        left = _provideBorders.transform.InverseTransformPoint(left);

        float x = Mathf.Abs(right.x - left.x);
        return new Vector3(x, colliderSize.y, colliderSize.z);
    }

    public (Vector3 right, Vector3 left) GetPositionRigthAndLeftPointMeshCar()
    {
        Vector3 right = _provideBorders.GetPositionMeshPoint(SideMeshObject.Right);
        Vector3 left = _provideBorders.GetPositionMeshPoint(SideMeshObject.Left);
        right = _provideBorders.transform.TransformPoint(right);
        left = _provideBorders.transform.TransformPoint(left);
        return (right, left);
    }
    
}
