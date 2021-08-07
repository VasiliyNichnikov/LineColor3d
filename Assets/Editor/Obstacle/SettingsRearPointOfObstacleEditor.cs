using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SettingsRearPointOfObstacle))]
public class SettingsRearPointOfObstacleEditor : Editor
{
    private SettingsRearPointOfObstacle _settingsRearPointOfObstacle;
    private Vector3 _behind = Vector3.zero;
    private const float _handleSize = 0.2f;

    private void OnEnable()
    {
        _settingsRearPointOfObstacle = (SettingsRearPointOfObstacle)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Determine The Back Point"))
        {
            _behind = _settingsRearPointOfObstacle.GettingMostBehindPoint();
            Vector3 center = _settingsRearPointOfObstacle.GetCenterPointTransformObjects();
            _behind = new Vector3(center.x, _behind.y, _behind.z);
            _settingsRearPointOfObstacle.ChangePointPosition(_behind);
        }
    }

    public void OnSceneGUI()
    {
        if (Event.current.type != EventType.Repaint || _settingsRearPointOfObstacle.ParameterObstacles == null ||
            _settingsRearPointOfObstacle.ParameterObstacles.Length <= 0) return;
        Vector3 point = _settingsRearPointOfObstacle.GetCenterPointTransformObjects();
        float size = HandleUtility.GetHandleSize(point);
        Handles.color = Color.red;
        Handles.SphereHandleCap(0, point, Quaternion.identity, size * _handleSize, EventType.Repaint);

        if (_settingsRearPointOfObstacle.Point != null)
        {
            Handles.color = Color.black;
            _behind = _settingsRearPointOfObstacle.Point.position;
            size = HandleUtility.GetHandleSize(_behind);
            Handles.SphereHandleCap(1, _behind, Quaternion.identity, size * _handleSize, EventType.Repaint);
        }
    }
}