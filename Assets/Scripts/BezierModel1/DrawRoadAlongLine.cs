using UnityEngine;

public class DrawRoadAlongLine : MonoBehaviour
{
    [SerializeField] private BeziersFirstOrder _beziers;
    [SerializeField] private GameObject _road;
    [SerializeField] private int _numberRoads;
    public BeziersFirstOrder Beziers => _beziers;
    public GameObject Road => _road;
    public int NumberRoads => _numberRoads;
    
}