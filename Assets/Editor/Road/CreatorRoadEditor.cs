using UnityEditor;
using UnityEngine;

namespace Editor.Road
{
    [CustomEditor(typeof(CreatorRoad))]
    public class CreatorRoadEditor : UnityEditor.Editor
    {
        private CreatorRoad _road;
    
        private void OnEnable()
        {
            _road = (CreatorRoad) target;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
        
            if (!_road.AutoUpdateRoad && GUILayout.Button("Обновить дорогу"))
            {
                _road.UpdateRoad();
            }else if (_road.AutoUpdateRoad)
            {
                _road.UpdateRoad();
            }
        
        }
    }
}
