using System;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
public class ParametersTwoPoints
{
    [SerializeField] private string _name;
    public Transform PointOne;
    public Transform PointTwo;

    public string Name => _name;
}
