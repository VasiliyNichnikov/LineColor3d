using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class CalculatePoints
{
    public static (Vector3 min, Vector3 max) GetLergePoint(Vector3 a, Vector3 b)
    {
        return a.magnitude > b.magnitude ? (b, a) : (a, b);
    }


    public static Vector2[] GetEventlySpacedPoints(Spline spline, float spacing)
    {
        List<Vector2> points = new List<Vector2>();
        Vector2 firstPoint = new Vector2(spline[0].x, spline[0].z);
        points.Add(firstPoint);
        Vector2 previousPoint = firstPoint;
        float distanceSinceLastEvenPoint = 0;
        
        int numberCurves = spline.NumberCurves;
        
        for(int indexCurve = 0; indexCurve < numberCurves; indexCurve++)
        {
            Vector3[] p3 = spline.GetPointsInCurves(indexCurve);
            Vector2[] p2 = GetPointsVector2(p3);
            
            float controlNetLength =
                Vector2.Distance(p2[0], p2[1]) + Vector2.Distance(p2[1], p2[2]) + Vector2.Distance(p2[2], p2[3]);
            float estimatedCurveLength = Vector2.Distance(p2[0], p2[3]) + controlNetLength / 2f;

            int divisions = Mathf.CeilToInt(estimatedCurveLength * 10);
            float t = 0;
            while (t <= 1)
            {
                t += 1f / divisions;
                Vector2 pointOnCurve = GetPointVector2(Bezier.GetPoint(p3[0], p3[1], p3[2], p3[3], t));
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
            
        }
        
        return points.ToArray();
    }

    private static Vector2[] GetPointsVector2(Vector3[] p3)
    {
        return p3.Select(p => new Vector2(p.x, p.z)).ToArray();
    }

    private static Vector2 GetPointVector2(Vector3 point)
    {
        return new Vector2(point.x, point.z);
    }
}