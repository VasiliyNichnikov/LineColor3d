using System;
using UnityEngine;

[Serializable]
public class ParameterObstacle : MonoBehaviour, IParameterObstacle
{
    public Transform Transform => _transform;
    public ProvideBordersObject ProvideBorders => _provideBorders;

    [SerializeField] private string _name;
    [SerializeField] private Transform _transform;
    [SerializeField] private ProvideBordersObject _provideBorders;
}