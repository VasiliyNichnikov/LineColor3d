using System.Collections;
using System.Collections.Generic;
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

        if (GUILayout.Button("Обновить дорогу"))
        {
            _creator.UpdateRoad();
        }
    }
}
