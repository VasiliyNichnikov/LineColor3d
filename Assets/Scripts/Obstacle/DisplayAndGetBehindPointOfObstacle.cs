using UnityEngine;

public class DisplayAndGetBehindPointOfObstacle : MonoBehaviour, IDisplayAndGetBehindPointOfObstacle
{
    public Transform Point { get => _point; set => _point = value; }
    
    [SerializeField, InterfaceType(typeof(IParameterObstacle))]
    private Object[] _parametersObstacle;
    [SerializeField] private Transform _point;
    private IParameterObstacle ParametersObstacle(int index) => _parametersObstacle[index] as IParameterObstacle;

    public IParameterObstacle[] GetArrayParameterObstacles()
    {
        return GetInterfaceArray.Getting(_parametersObstacle, ParametersObstacle);
    }
}