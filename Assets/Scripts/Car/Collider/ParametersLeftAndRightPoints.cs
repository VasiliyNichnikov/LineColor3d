using System;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
public class ParametersLeftAndRightPoints
{
    [SerializeField] private string _name;
    [SerializeField] private Axis _axis;
    public Transform Right;
    public Transform Left;

    public string Name => _name;
    public Axis Axis => _axis;
}
