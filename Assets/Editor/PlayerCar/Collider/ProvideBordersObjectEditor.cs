using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ProvideBordersObject))]
public class ProvideBordersCarEditor : Editor
{
    private ProvideBordersObject _borders;
    private UnityEngine.Transform _handleTransform;
    private Quaternion _handleRotation;
    private const float _handleSize = 0.1f;


    private readonly SideMeshCar[] _sides = 
    {
        SideMeshCar.Up,
        SideMeshCar.Center,
        SideMeshCar.Right,
        SideMeshCar.Left,
        SideMeshCar.Forward,
        SideMeshCar.Behind
    };

    private readonly Color[] _colorsButtons =
    {
        Color.green,
        Color.magenta,
        Color.blue,
        Color.blue,
        Color.cyan,
        Color.cyan
    };

    private Vector3[] _positions;
    

    private void OnEnable()
    {
        _borders = (ProvideBordersObject) target;
        
        _handleTransform = _borders.transform;
        _borders.SelectedPointId = 0;
        _handleRotation = _handleTransform.rotation;
        _handleRotation = Tools.pivotRotation == PivotRotation.Local ? _handleRotation : Quaternion.identity;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        
        if(_positions == null) return;
        
        for (int i = 0; i < _sides.Length; i++)
        {
            if (_borders.SelectedPointId == i)
            {
                GUILayout.Label($"Выбранная точка ({_borders.SelectedPointId}):");
                GUILayout.Label($"Позиция: {_positions[i]}");
            }
        }
    }

    private void OnSceneGUI()
    {
        _positions = new Vector3[_sides.Length];
        
        for (int i = 0; i < _sides.Length; i++)
        {
            _positions[i] = GetMeshPositionInGlobalCoordinates(_sides[i]);
        }

        for (int i = 0; i < _sides.Length; i++)
        {
            CreatingButtonInTheFormSphere(_positions[i], _colorsButtons[i], i);
        }
        
        Handles.Label(_positions[_borders.SelectedPointId], $"Position: {_positions[_borders.SelectedPointId]}");
    }

    private Vector3 GetMeshPositionInGlobalCoordinates(SideMeshCar sideMeshCar)
    {
        Vector3 position = _borders.GetPositionMeshPoint(sideMeshCar);
        position = _handleTransform.TransformPoint(position);
        return position;
    }

    private void CreatingButtonInTheFormSphere(Vector3 point, Color color, int id)
    {
        float size = HandleUtility.GetHandleSize(point);
        DrawSphere(point, size * _handleSize, color);
        InterationWithButton(point, size * _handleSize, id);
    }
    
    private void DrawSphere(Vector3 point, float size, Color color)
    {
        point = _handleTransform.TransformPoint(point);
        Handles.color = color;
        Handles.SphereHandleCap(0, point, _handleRotation, size * _handleSize, EventType.Repaint);
    }

    private void InterationWithButton(Vector3 position, float size, int id)
    {
        if (Handles.Button(position, Quaternion.identity, size, size, Handles.SphereHandleCap))
        {
            _borders.SelectedPointId = id;
        }
    }
}