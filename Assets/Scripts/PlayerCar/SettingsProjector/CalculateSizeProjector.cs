using System;
using UnityEngine;

public class CalculateSizeProjector : MonoBehaviour
{
    public float GetSizeProjectorSelectedAxes(Transform projector, Vector3 pointOne, Vector3 pointTwo, Axis axis)
    {
        switch (axis)
        {
            case Axis.X:
                return Mathf.Abs(pointOne.x - pointTwo.x);

            case Axis.Y:
                return Mathf.Abs(pointOne.y - pointTwo.y);

            case Axis.Z:
                return Mathf.Abs(pointOne.y - pointTwo.y);

            default:
                throw new ArgumentOutOfRangeException(nameof(axis), axis, null);
        }
    }
}