using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

[assembly: InternalsVisibleTo("Tests")]
public class ArrayObjectsRoad : MonoBehaviour
{
    private IDisplayAndGetBehindPointOfObstacle GetBehindPointOfObstacle(int index) =>
        _getBehindPointOfObstacles[index] as IDisplayAndGetBehindPointOfObstacle;

    [SerializeField, InterfaceType(typeof(IDisplayAndGetBehindPointOfObstacle))]
    private Object[] _getBehindPointOfObstacles;
    
    private Queue<Vector3> _mapPositions;
    private SortObjectsRoad _sortObjectsRoad;
    
    private IDisplayAndGetBehindPointOfObstacle[] GetArrayBehindPointOfObstacles()
    {
        return GetInterfaceArray.Getting(_getBehindPointOfObstacles, GetBehindPointOfObstacle);
    }
    
    private void Awake()
    {
        IDisplayAndGetBehindPointOfObstacle[] displayAndGetBehindPoint = GetArrayBehindPointOfObstacles();
        _sortObjectsRoad = new SortObjectsRoad();
        _mapPositions = _sortObjectsRoad.GettingSortArray(displayAndGetBehindPoint);
    }

    public Vector3 GetAndRemoveFirstElementPosition()
    {
        if(_mapPositions.Count != 0)
            return _mapPositions.Dequeue();
        return Vector3.zero;
    }
    
}
