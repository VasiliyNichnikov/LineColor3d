using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CalculatePoints
{
    public static Vector3 GetLergePoint(Vector3 a, Vector3 b)
    {
        return a.magnitude > b.magnitude ? a : b;
    }
}