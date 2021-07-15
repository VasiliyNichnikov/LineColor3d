using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(BezierCurve))]
public class BezierCurveEditor : Editor
{
    private BezierCurve _curve;
    private Transform _handleTransform;
    private Quaternion _handleRotation;

    private const int _lineSteps = 10;
    private const float _directionScale = 0.5f;

    private void OnSceneGUI()
    {
        _curve = (BezierCurve) target;
        _handleTransform = _curve.transform;
        _handleRotation = Tools.pivotRotation == PivotRotation.Local ? _handleRotation : Quaternion.identity;

        Vector3 p0 = ShowPoint(0);
        Vector3 p1 = ShowPoint(1);
        Vector3 p2 = ShowPoint(2);
        Vector3 p3 = ShowPoint(3);
        
        Handles.color = Color.gray;
        Handles.DrawLine(p0, p1);
        Handles.DrawLine(p2, p3);
        
        ShowDirections();
        Handles.DrawBezier(p0, p3, p1, p2, Color.white, null, _directionScale);
    }
    
    private Vector3 ShowPoint(int index)
    {
        Vector3 point = _handleTransform.TransformPoint(_curve.Points[index]);
        EditorGUI.BeginChangeCheck();
        point = Handles.DoPositionHandle(point, _handleRotation);
        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(_curve, "Move Point");
            EditorUtility.SetDirty(_curve);
            _curve.Points[index] = _handleTransform.InverseTransformPoint(point);
        }

        return point;
    }

    private void ShowDirections()
    {
        Handles.color = Color.green;
        Vector3 point = _curve.GetPoint3(0f);
        Handles.DrawLine(point, point + _curve.GetDirection(0f) * _directionScale);
        for (int i = 1; i <= _lineSteps; i++)
        {
            point = _curve.GetPoint3(i / (float) _lineSteps);
            Handles.DrawLine(point, point + _curve.GetDirection(i / (float)_lineSteps * _directionScale));
        }
    }
    
}
