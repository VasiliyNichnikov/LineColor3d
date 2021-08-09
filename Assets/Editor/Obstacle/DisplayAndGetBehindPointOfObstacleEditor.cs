using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(DisplayAndGetBehindPointOfObstacle))]
public class DisplayAndGetBehindPointOfObstacleEditor : Editor
{
    private DisplayAndGetBehindPointOfObstacle _displayAndGetBehindPoint;
    private Vector3 _behind = Vector3.zero;
    private const float _handleSize = 0.2f;
    
    private void OnEnable()
    {
        _displayAndGetBehindPoint = (DisplayAndGetBehindPointOfObstacle)target;
    }
    
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
    
        if (GUILayout.Button("Determine The Back Point"))
        {
            IParameterObstacle[] parameterObstacles = _displayAndGetBehindPoint.GetArrayParameterObstacles();
            _behind = SettingsBehindPointOfObstacle.GettingMostBehindPoint(parameterObstacles);
            if(_displayAndGetBehindPoint.Point == null)
            {
                _displayAndGetBehindPoint.Point =
                    SettingsBehindPointOfObstacle.CreatingPointAndSelectingParent(_displayAndGetBehindPoint.transform);
            }
            _displayAndGetBehindPoint.Point.position = _behind;
        }
    }
    
    public void OnSceneGUI()
    {
        IParameterObstacle[] parameterObstacles = _displayAndGetBehindPoint.GetArrayParameterObstacles();
        if (Event.current.type != EventType.Repaint || parameterObstacles== null ||
            parameterObstacles.Length <= 0) return;
            
        Vector3 point = SettingsBehindPointOfObstacle.GetCenterPointTransformObjects(parameterObstacles);
        float size = HandleUtility.GetHandleSize(point);
        Handles.color = Color.red;
        Handles.SphereHandleCap(0, point, Quaternion.identity, size * _handleSize, EventType.Repaint);
        
        if (_displayAndGetBehindPoint.Point != null)
        {
            Handles.color = Color.black;
            _behind = _displayAndGetBehindPoint.Point.position;
            size = HandleUtility.GetHandleSize(_behind);
            Handles.SphereHandleCap(1, _behind, Quaternion.identity, size * _handleSize, EventType.Repaint);
        }
    }
}