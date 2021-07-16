using System.Collections.Generic;
using System.Linq;
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
        
        Vector2[] p = GetPointsVector2(bezier);
        points.Add(p[0]);
        Vector2 previousPoint = p[0];
        float distanceSinceLastEvenPoint = 0;
        
        float controlNetLength =
            Vector2.Distance(p[0], p[1]) + Vector2.Distance(p[1], p[2]) + Vector2.Distance(p[2], p[3]);
        float estimatedCurveLength = Vector2.Distance(p[0], p[3]) + controlNetLength / 2f;

        int divisions = Mathf.CeilToInt(estimatedCurveLength * 10);
        float t = 0;
        while (t <= 1)
        {
            t += 1f / divisions;
            Vector2 pointOnCurve = GetPointVector2(bezier.GetPointNotTransformPoint(t));
            distanceSinceLastEvenPoint += Vector2.Distance(previousPoint, pointOnCurve);

            while (distanceSinceLastEvenPoint >= spacing)
            {
                float overshootDistance = distanceSinceLastEvenPoint - spacing;
                Vector2 newEventlySpacedPoint =
                    pointOnCurve + (previousPoint - pointOnCurve).normalized * overshootDistance;
                points.Add(newEventlySpacedPoint);
                distanceSinceLastEvenPoint = overshootDistance;
                previousPoint = newEventlySpacedPoint;
            }

            previousPoint = pointOnCurve;
        }
        
        return points.ToArray();
    }

    private static Vector2[] GetPointsVector2(BezierCurve bezier)
    {
        return bezier.Points.Select(p => new Vector2(p.x, p.z)).ToArray();
    }

    private static Vector2 GetPointVector2(Vector3 point)
    {
        return new Vector2(point.x, point.z);
    }
}