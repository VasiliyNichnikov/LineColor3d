using UnityEngine;

public static class SettingsBehindPointOfObstacle
{
    public static Vector3 GettingMostBehindPoint(IParameterObstacle[] parameterObstacles)
    {
        Vector3 center = GetCenterPointTransformObjects(parameterObstacles);
        IParameterObstacle behind = null;

        foreach (var obstacle in parameterObstacles)
        {
            Vector3 position = obstacle.Transform.position;
            if ((position.z <= center.z && behind == null) || position.z <= behind.Transform.position.z)
            {
                behind = obstacle;
            }
        }

        ProvideBordersObject borderObject = behind.ProvideBorders;
        Vector3 behindPosition = borderObject.GetPositionMeshPoint(SideMeshObject.Behind);
        behindPosition = borderObject.transform.TransformPoint(behindPosition);
        behindPosition = new Vector3(center.x, behindPosition.y, behindPosition.z);
        return behind != null ? behindPosition : Vector3.zero;
    }

    public static Transform CreatingPointAndSelectingParent(Transform parent)
    {
        Transform point = new GameObject("Behind Point").transform;
        point.SetParent(parent);
        return point;
    }
    
    public static Vector3 GetCenterPointTransformObjects(IParameterObstacle[] parameterObstacles)
    {
        Vector3 center = Vector3.zero;
        int lenObjects = parameterObstacles.Length;
        foreach (var obstacle in parameterObstacles)
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
}