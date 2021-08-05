﻿using UnityEngine;

public static class Bezier{
    public static Vector3 GetPoint(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
    {
        t = Mathf.Clamp01(t);
        float oneMinusT = 1f - t;
        return Mathf.Pow(oneMinusT, 3) * p0 + 
               3f * t * Mathf.Pow(oneMinusT, 2) * p1 + 
               3f * Mathf.Pow(t, 2) * oneMinusT * p2 +
               Mathf.Pow(t, 3) * p3;
    }

    public static Vector3 GetFirstDerivative(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
    {
        t = Mathf.Clamp01(t);
        float oneMinusT = 1f - t;
        return 3f * oneMinusT * oneMinusT * (p1 - p0) +
               6f * oneMinusT * t * (p2 - p1) +
               3f * t * t * (p3 - p2);
    }
}
