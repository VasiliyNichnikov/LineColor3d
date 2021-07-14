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

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Растянуть дорогу по всей прямой"))
        {
            StretchRoadInStraightLine();
        }
    }

    private void StretchRoadInStraightLine()
    {
        var minAndMaxPoint = CalculatePoints.GetLergePoint(_road.BeziersFirstOrder.P0, _road.BeziersFirstOrder.P1);
        Vector3 min = _road.transform.InverseTransformPoint(minAndMaxPoint.min);
        Vector3 max = _road.transform.InverseTransformPoint(minAndMaxPoint.max);

        Vector3 start = _road.transform.position;
        
        ControlMesh.ShiftingPositionVertices(ref _mesh, Side.UpRight, max - start);
        ControlMesh.ShiftingPositionVertices(ref _mesh, Side.UpLeft, max - start);
        
        ControlMesh.ShiftingPositionVertices(ref _mesh, Side.DownRight, min - start);
        ControlMesh.ShiftingPositionVertices(ref _mesh, Side.DownLeft, min - start);


        _mesh.RecalculateBounds();
        _mesh.RecalculateNormals();
        _mesh.RecalculateTangents();
    }

    private void OnSceneGUI()
    {
        Vector3 center = _mesh.bounds.center;
        float size = HandleUtility.GetHandleSize(center);
        if (_road.ActiveLabelPosition)
        {
            Handles.Label(_road.transform.TransformPoint(center) + Vector3.up * 0.2f, $"Position: {_road.transform.TransformPoint(center)}");
        }
        Handles.color = Color.green;
        Handles.CubeHandleCap(0, _road.transform.TransformPoint(center), Quaternion.identity, _handleSize * size, EventType.Repaint);
        
        for (int i = 0; i < _verticles.Length; i++)
        {
            Vector3 point = _verticles[i];
            size = HandleUtility.GetHandleSize(point);
            if (_road.ActiveLabelPosition)
            {
                Handles.Label(_road.transform.TransformPoint(point) + Vector3.up * 0.2f, $"Position: {_road.transform.TransformPoint(point)}");
            }
            
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
            
            Handles.CubeHandleCap(0, _road.transform.TransformPoint(point), Quaternion.identity, _handleSize * size, EventType.Repaint);
        }
    }
}
