using System;
using UnityEngine;

public class CalculateTwoPoints
{
    public static float GetLengthBetweenTwoPointsOnSelectedAxis(Vector3 one, Vector3 two, Axis axis)
    {
        switch (axis)
        {
            case Axis.X:
                return Mathf.Abs(one.x - two.x);

            case Axis.Y:
                return Mathf.Abs(one.y - two.y);

            case Axis.Z:
                return Mathf.Abs(one.z - two.z);

            default:
                throw new ArgumentOutOfRangeException(nameof(axis), axis, null);
        }
    }
}
