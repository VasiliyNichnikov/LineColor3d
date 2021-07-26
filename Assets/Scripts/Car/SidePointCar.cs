using System;
using UnityEngine;

[Serializable]
public class SidePointCar
{
    [SerializeField] private string _name;
    [SerializeField] private SideCar _side;
    [SerializeField] private Transform _transform;
    public SideCar Side => _side;
    public Vector3 Position => _transform.position;
    public Transform Transform => _transform;
}