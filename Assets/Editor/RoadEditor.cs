using System;
using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(Road))]
public class RoadEditor : Editor
{
    private Road _road;
    private Mesh _mesh;
    private Vector3[] _verticles;
    private const float _handleSize = 0.1f;
    
    private void OnEnable()
    {
        _road = (Road) target;
        _mesh = _road.GetComponent<MeshFilter>().sharedMesh;
        _verticles = _mesh.vertices;
    }

    private void OnSceneGUI()
    {
        
        for (int i = 0; i < _verticles.Length; i++)
        {
            Vector3 point = _verticles[i];
            float size = HandleUtility.GetHandleSize(point);
            if (_road.ActiveLabelPosition)
                Handles.Label(_road.transform.position + point + Vector3.up * 0.2f, $"Position: {point}");
            
            if (point.z <= -0.99f)
            {
                // Down
                Handles.color = Color.blue;
            }
            else if (point.z >= 0.99f)
            {
                // Forward
                Handles.color = Color.yellow;
            }
            else
            {
                Handles.color = Color.red;
            }
            
            Handles.CubeHandleCap(0, _road.transform.position + point, Quaternion.identity, _handleSize * size, EventType.Repaint);
        }
    }
}
