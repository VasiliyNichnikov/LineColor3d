using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MovementCar))]
public class MovementCarEditor : Editor
{
    private MovementCar _movementCar;
    private Transform _handleTransform;
    private Quaternion _handleRotation;

    private void OnEnable()
    {
        _movementCar = (MovementCar) target;
    }

    private void OnSceneGUI()
    {
        _handleTransform = _movementCar.transform;
        _handleRotation = _handleTransform.rotation;
        _handleRotation = Tools.pivotRotation == PivotRotation.Local ? _handleRotation : Quaternion.identity;

        ChangePosition(ref _movementCar.Positions.StartPosition);
        ChangePosition(ref _movementCar.Positions.EndPosition);
        
        Handles.color = Color.black;
        Handles.DrawLine(_movementCar.Positions.StartPosition, _movementCar.Positions.EndPosition);
    }

    private void ChangePosition(ref Vector3 position)
    {
        EditorGUI.BeginChangeCheck();
        position = Handles.DoPositionHandle(position, _handleRotation);

        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(_movementCar, "Move point");
            EditorUtility.SetDirty(_movementCar);
        }
    }
    
}
