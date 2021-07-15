using System;
using System.Collections.Generic;
using UnityEngine;

public static class CalculatePoints
{
    public static (Vector3 min, Vector3 max) GetLergePoint(Vector3 a, Vector3 b)
    {
        return a.magnitude > b.magnitude ? (b, a) : (a, b);
    }
    
    public static Vector2[] GetEventlySpacedPoints(BezierCurve bezier, float spacing)
    {
        List<Vector2> points = new List<Vector2>();
        int steps = Convert.ToInt32(1.0f / spacing);
        for (int i = 0; i < steps; i++)
        {
            Vector3 point = bezier.GetPoint3(spacing * i);
            Vector2 readyPoint = new Vector2(point.x, point.z);
            points.Add(readyPoint);
        }

        return points.ToArray();
    }
    
}