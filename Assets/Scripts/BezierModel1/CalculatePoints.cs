using UnityEngine;

public static class CalculatePoints
{
    public static (Vector3 min, Vector3 max) GetLergePoint(Vector3 a, Vector3 b)
    {
        return a.magnitude > b.magnitude ? (b, a) : (a, b);
    }
    
    
}