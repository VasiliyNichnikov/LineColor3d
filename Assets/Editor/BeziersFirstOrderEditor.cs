
using System;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

[CustomEditor(typeof(BeziersFirstOrder))]
public class BeziersFirstOrderEditor : Editor
{
    private BeziersFirstOrder _beziers;

    private void OnEnable()
    {
        _beziers = (BeziersFirstOrder) target;
    }

    private void OnSceneGUI()
    {
        Transform handleTransform = _beziers.transform;
        Quaternion handleRotation =
            Tools.pivotRotation == PivotRotation.Local ? handleTransform.rotation : Quaternion.identity;

        Vector3 p0 = handleTransform.TransformPoint(_beziers.P0);
        Vector3 p1 = handleTransform.TransformPoint(_beziers.P1);
        
        Handles.color = Color.blue;
        Handles.DrawLine(p0, p1);

        Handles.DoPositionHandle(p0, handleRotation);
        Handles.DoPositionHandle(p1, handleRotation);

        _beziers.P0 = GetChangePositionPoint(ref p0, handleTransform, handleRotation);
        _beziers.P1 = GetChangePositionPoint(ref p1, handleTransform, handleRotation);
    }

    private Vector3 GetChangePositionPoint(ref Vector3 p, Transform handleTransform, Quaternion handleRotation)
    {
        EditorGUI.BeginChangeCheck();
        p = Handles.DoPositionHandle(p, handleRotation);
        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(_beziers, "Move point");
            EditorUtility.SetDirty(_beziers);
        }
        return handleTransform.InverseTransformPoint(p);
    }
    
}
