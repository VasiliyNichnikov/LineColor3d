using System;
using UnityEngine;

public class CalculateTwoPoints
{
    public static float GetLengthBetweenTwoPointsOnSelectedAxis(SubtractionAxis axis, Vector3 one, Vector3 two)
    {
        return Mathf.Abs(axis.Subtract(one, two));
    }
}
