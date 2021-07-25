using System;
using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(CalculatingBoxColliderCarBody))]
public class CalculatingBoxColliderCarBodyEditor : Editor
{
    private CalculatingBoxColliderCarBody _calculatingMesh;
    private Transform _handleTransform;
    private Quaternion _handleRotation;
    private const float _handleSize = 0.1f;

    private void OnEnable()
    {
        _calculatingMesh = (CalculatingBoxColliderCarBody) target;
        
        _handleTransform = _calculatingMesh.transform;
        _handleRotation = Tools.pivotRotation == PivotRotation.Local ? _handleRotation : Quaternion.identity;
    }

    private void OnSceneGUI()
    {
        Vector3 centerPoint = _calculatingMesh.MeshCar.bounds.center;
        float size = HandleUtility.GetHandleSize(centerPoint);
        Handles.color = Color.red;
        Handles.SphereHandleCap(0, centerPoint, _handleRotation, size * _handleSize, EventType.Repaint);
        
        Handles.color = Color.blue;
        Vector3 upPoint =
            _calculatingMesh.MeshCar.bounds.ClosestPoint(new Vector3(centerPoint.x, Mathf.Infinity, centerPoint.z));
        Handles.SphereHandleCap(0, upPoint, _handleRotation, size * _handleSize, EventType.Repaint);
    }
}
