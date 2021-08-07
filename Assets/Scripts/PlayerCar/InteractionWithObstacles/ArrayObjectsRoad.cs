using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ArrayObjectsRoad : MonoBehaviour
{
    [SerializeField] private SettingsRearPointOfObstacle[] _settingsRearPointOfObstacle;
    private Queue<Vector3> _mapPositions;
    
    private void Awake()
    {
        _mapPositions = new Queue<Vector3>();
        Vector3[] points = new Vector3[_settingsRearPointOfObstacle.Length];
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = _settingsRearPointOfObstacle[i].Point.position;
        }
    
        points = points.OrderBy(v => v.z).ToArray();
        foreach (var position in points)
        {
            _mapPositions.Enqueue(position);
        }
    }

    public Vector3 GetAndRemoveFirstElementPosition()
    {
        if(_mapPositions.Count != 0)
            return _mapPositions.Dequeue();
        return Vector3.zero;
    }
    
}
