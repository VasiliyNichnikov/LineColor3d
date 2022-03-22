using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(Line))]
    public class LineEditor : UnityEditor.Editor
    {
        private Line _line;
    
        private void OnSceneGUI()
        {
            _line = (Line) target;

            Transform handleTransform = _line.transform;
            Quaternion handleRotation =
                Tools.pivotRotation == PivotRotation.Local ? handleTransform.rotation : Quaternion.identity;
        
            Vector3 p0 = handleTransform.TransformPoint(_line.p0);
            Vector3 p1 = handleTransform.TransformPoint(_line.p1);
        
            Handles.color = Color.black;
            Handles.DrawLine(p0, p1);

            Handles.DoPositionHandle(p0, handleRotation);
            Handles.DoPositionHandle(p1, handleRotation);
        
            EditorGUI.BeginChangeCheck();
            p0 = Handles.DoPositionHandle(p0, handleRotation);
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(_line, "Move point");
                EditorUtility.SetDirty(_line);
                _line.p0 = handleTransform.InverseTransformPoint(p0);
            }
        
            EditorGUI.BeginChangeCheck();
            p1 = Handles.DoPositionHandle(p1, handleRotation);
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(_line, "Move point");
                EditorUtility.SetDirty(_line);
                _line.p1 = handleTransform.InverseTransformPoint(p1);
            }
        }
    }
}
