using UnityEngine;

public class Road : MonoBehaviour
{
    [SerializeField] private BeziersFirstOrder _beziersFirstOrder;
    [SerializeField] private bool _activeLabelPosition;
    public bool ActiveLabelPosition => _activeLabelPosition;
    public BeziersFirstOrder BeziersFirstOrder => _beziersFirstOrder;
}