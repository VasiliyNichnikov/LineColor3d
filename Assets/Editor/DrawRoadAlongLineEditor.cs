using System;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(DrawRoadAlongLine))]
public class DrawRoadAlongLineEditor : Editor
{
    private DrawRoadAlongLine _drawRoad;
    private GameObject _road;
    private Transform _handleTransfrom;
    private Quaternion _handleRotation;
    private Mesh _roadMesh;

    private void OnEnable()
    {
        _drawRoad = (DrawRoadAlongLine) target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Create Road"))
        {
            Vector3 position = Vector3.zero;
            _road = Instantiate(_drawRoad.Road, position, Quaternion.identity);
            _road.transform.SetParent(_drawRoad.transform);
            _roadMesh = _road.GetComponent<MeshFilter>().mesh;
            
            _handleTransfrom = _drawRoad.transform;
            _handleRotation = Tools.pivotRotation == PivotRotation.Local
                ? _handleTransfrom.rotation
                : Quaternion.identity;
            // ClearCreatedRoads();
            // DrawRoads();
        }

        if (GUILayout.Button("Clear road"))
        {
            if (_road != null)
                DestroyImmediate(_road);
            // ClearCreatedRoads();
        }
    }

    private void OnSceneGUI()
    {
        if (_roadMesh != null)
        {
            for (int i = 0; i < _roadMesh.vertexCount; i++)
            {
                ShowHandle(i);
            }
        }
    }

    private void ShowHandle(int index)
    {
        Vector3 point = _handleTransfrom.TransformPoint(_roadMesh.vertices[index]);
        Handles.color = Color.blue;
        if (Handles.Button(point, _handleRotation, 2, 2, Handles.DotHandleCap))
        {
            
        }
    }

    private void ClearCreatedRoads()
    {
        // EditorGUI.BeginChangeCheck();
        // Road[] roads = _drawRoad.transform.GetComponentsInChildren<Road>();
        // if (roads.Length > 0)
        // {
        //     for (int i = 0; i < roads.Length; i++)
        //     {
        //         DestroyImmediate(roads[i].gameObject);
        //     }
        // }
        // if (EditorGUI.EndChangeCheck())
        // {
        //     Undo.RecordObject(_drawRoad, "Clear Roads");
        //     EditorUtility.SetDirty(_drawRoad);
        // }
    }

    private void DrawRoads()
    {
        // Vector3 position = Vector3.zero;
        // _createdRoads = new GameObject[_drawRoad.NumberRoads];
        // for (int i = 0; i < _drawRoad.NumberRoads; i++)
        // {
        //     _createdRoads[i] = Instantiate(_drawRoad.Road, position, Quaternion.identity);
        //     _createdRoads[i].transform.SetParent(_drawRoad.transform);
        //     position = new Vector3(0, 0, position.z + 2);
        // }
    }
}