using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(CalculatorBoxColliderCarBody))]
public class CalculatorBoxColliderCarBodyEditor : Editor
{
    private CalculatorBoxColliderCarBody _calculatorMesh;
    private Transform _handleTransform;
    private Quaternion _handleRotation;
    private const float _handleSize = 0.1f;

    private void OnEnable()
    {
        _calculatorMesh = (CalculatorBoxColliderCarBody) target;

        _handleTransform = _calculatorMesh.transform;
        _handleRotation = Tools.pivotRotation == PivotRotation.Local ? _handleRotation : Quaternion.identity;
    }

    private void OnSceneGUI()
    {
        Vector3 centerPoint = _calculatorMesh.MeshCar.bounds.center;

        Vector3 upPoint =
            _calculatorMesh.MeshCar.bounds.ClosestPoint(new Vector3(centerPoint.x, Mathf.Infinity, centerPoint.z));
        Vector3 forwardPoint =
            _calculatorMesh.MeshCar.bounds.ClosestPoint(new Vector3(centerPoint.x, centerPoint.y, Mathf.Infinity));
        Vector3 behindPoint =
            _calculatorMesh.MeshCar.bounds.ClosestPoint(new Vector3(centerPoint.x, centerPoint.y, -Mathf.Infinity));
        Vector3 rightPoint =
            _calculatorMesh.MeshCar.bounds.ClosestPoint(new Vector3(Mathf.Infinity, centerPoint.y, centerPoint.z));
        Vector3 leftPoint =
            _calculatorMesh.MeshCar.bounds.ClosestPoint(new Vector3(-Mathf.Infinity, centerPoint.y, centerPoint.z));
        
        DrawPoint(centerPoint, Color.red);
        
        DrawPoint(upPoint, Color.blue);
        DrawPoint(forwardPoint, Color.blue);
        DrawPoint(behindPoint, Color.blue);
        
        DrawPoint(rightPoint, Color.blue);
        DrawPoint(leftPoint, Color.blue);
    }

    private void DrawPoint(Vector3 point, Color color)
    {
        float size = HandleUtility.GetHandleSize(point);
        point = _handleTransform.TransformPoint(point);
        Handles.color = color;
        Handles.SphereHandleCap(0, point, _handleRotation, size * _handleSize, EventType.Repaint);
    }
}