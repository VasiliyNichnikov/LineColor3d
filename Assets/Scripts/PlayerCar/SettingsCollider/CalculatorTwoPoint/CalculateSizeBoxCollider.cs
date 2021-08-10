using UnityEngine;

public class CalculateSizeBoxCollider : MonoBehaviour
{
    public Vector3 GetSizeBoxCollider(BoxCollider boxCollider, IProvideBordersObject provideBorders)
    {
        Vector3 colliderSize = boxCollider.size;

        Vector3 right = provideBorders.GetPositionMeshPoint(SideMeshObject.Right);
        Vector3 left = provideBorders.GetPositionMeshPoint(SideMeshObject.Left);

        SubtractionAxis subtractionAxisX = new SubtractionAxisX();
        float x = CalculateTwoPoints.GetLengthBetweenTwoPointsOnSelectedAxis(subtractionAxisX, right, left);
        return new Vector3(x, colliderSize.y, colliderSize.z);
    }

    public Vector3 GetSizeBoxCollider(BoxCollider boxCollider, Vector3 right, Vector3 left)
    {
        Vector3 colliderSize = boxCollider.size;
        
        SubtractionAxis subtractionAxisX = new SubtractionAxisX();
        float x = CalculateTwoPoints.GetLengthBetweenTwoPointsOnSelectedAxis(subtractionAxisX,right, left) / 100f;
        return new Vector3(x, colliderSize.y, colliderSize.z);
    }

    public (Vector3 right, Vector3 left) GetPositionRigthAndLeftPointMeshCar(IProvideBordersObject provideBorders)
    {
        Vector3 right = provideBorders.GetPositionMeshPoint(SideMeshObject.Right);
        Vector3 left = provideBorders.GetPositionMeshPoint(SideMeshObject.Left);
        right = provideBorders.Transform.TransformPoint(right);
        left = provideBorders.Transform.TransformPoint(left);
        return (right, left);
    }
}