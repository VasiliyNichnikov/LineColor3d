using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(LineMoveCar))]
public class LineMoveCarEditor : Editor
{
    private LineMoveCar _lineMove;
    private Transform _handleTransform;
    private Quaternion _handleRotation;

    private void OnEnable()
    {
        _lineMove = (LineMoveCar) target;
    }

    private void OnSceneGUI()
    {
        _handleTransform = _lineMove.transform;
        _handleRotation = _handleTransform.rotation;
        _handleRotation = Tools.pivotRotation == PivotRotation.Local ? _handleRotation : Quaternion.identity;

        ChangePosition(ref _lineMove.StartPosition);
        ChangePosition(ref _lineMove.EndPosition);
        
        Handles.color = Color.black;
        Handles.DrawLine(_lineMove.StartPosition, _lineMove.EndPosition);
    }

    private void ChangePosition(ref Vector3 position)
    {
        EditorGUI.BeginChangeCheck();
        position = Handles.DoPositionHandle(position, _handleRotation);

        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(_lineMove, "Move point");
            EditorUtility.SetDirty(_lineMove);
        }
    }
    
}
