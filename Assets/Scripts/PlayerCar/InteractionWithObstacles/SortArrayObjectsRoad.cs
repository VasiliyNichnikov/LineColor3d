using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SortArrayObjectsRoad : MonoBehaviour
{
    [SerializeField] private ProvideBordersObject[] _provideBordersObjects;
    private Queue<Vector3> _mapPositions;
    
    private void Awake()
    {
        _mapPositions = new Queue<Vector3>();
        Vector3[] _positionsBehindPoints = new Vector3[_provideBordersObjects.Length];
        for (int i = 0; i < _positionsBehindPoints.Length; i++)
        {
            _positionsBehindPoints[i] = _provideBordersObjects[i].GetPositionMeshPoint(SideMeshObject.Behind);
            _positionsBehindPoints[i] = _provideBordersObjects[i].transform.TransformPoint(_positionsBehindPoints[i]);
        }
    
        _positionsBehindPoints = _positionsBehindPoints.OrderBy(v => v.z).ToArray();
        foreach (var position in _positionsBehindPoints)
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
