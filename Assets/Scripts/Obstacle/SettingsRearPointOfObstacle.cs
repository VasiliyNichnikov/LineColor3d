using UnityEngine;

public class SettingsRearPointOfObstacle : MonoBehaviour
{
    public ParameterObstacle[] ParameterObstacles;
    public Transform Point;

    public Vector3 GettingMostBehindPoint()
    {
        Vector3 center = GetCenterPointTransformObjects();
        ParameterObstacle behind = null;

        foreach (var obstacle in ParameterObstacles)
        {
            Vector3 position = obstacle.Transform.position;
            if (position.z <= center.z)
            {
                behind = obstacle;
            }
        }

        ProvideBordersObject borderObject = behind.ProvideBorders;
        Vector3 behindPosition = borderObject.GetPositionMeshPoint(SideMeshObject.Behind);
        behindPosition = borderObject.transform.TransformPoint(behindPosition);
        
        return behind != null ? behindPosition : Vector3.zero;
    }

    public void ChangePointPosition(Vector3 position)
    {
        if (Point == null)
        {
            Point = new GameObject("Behind Point").transform;
            Point.SetParent(transform);
        }

        Point.position = position;
    }
    
    public Vector3 GetCenterPointTransformObjects()
    {
        Vector3 center = Vector3.zero;
        int lenObjects = ParameterObstacles.Length;
        foreach (var obstacle in ParameterObstacles)
        {
            if (obstacle == null) return Vector3.zero;

            Vector3 position = obstacle.Transform.position;
            center.x += position.x;
            center.y += position.y;
            center.z += position.z;
        }

        center /= lenObjects;
        return center;
    }


    private bool CheckExistencePoint()
    {
        return Point != null;
    }

    private void CreateBehindPoint()
    {
        Point = new GameObject("Behind point").transform;
        Point.SetParent(transform);
    }
}