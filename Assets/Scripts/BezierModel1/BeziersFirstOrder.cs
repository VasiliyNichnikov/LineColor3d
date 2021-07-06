using System;
using UnityEngine;

public class BeziersFirstOrder : MonoBehaviour
{
    [SerializeField] private Vector3 _p0;
    [SerializeField] private Vector3 _p1;

    public Vector3 P0
    {
        get => _p0;
        set => _p0 = value;
    }

    public Vector3 P1
    {
        get => _p1;
        set => _p1 = value;
    }

    public Vector3 GetPoint(float t)
    {
        if (t < 0 && t > 1)
        {
            throw new Exception("значение t не входит в диапазон: [0, 1]");
        }
        Vector3 point = (1 - t) * _p0 + t * _p1;
        return point;
    }
    
}
