using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CreatorRoad))]
public class CreatorRoadEditor : Editor
{
    private CreatorRoad _creator;
    
    public override void OnInspectorGUI()
    {
        _creator = (CreatorRoad) target;
        base.OnInspectorGUI();

        if (!_creator.AutoUpdate && GUILayout.Button("Обновить дорогу"))
        {
            _creator.UpdateRoad();
        }else if (_creator.AutoUpdate)
        {
            _creator.UpdateRoad();
        }
    }
}
