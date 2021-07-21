using System;
using UnityEngine;

public class ChangeSizeCar : MonoBehaviour
{
    [SerializeField] private float _hValue = 0.0f;
    [SerializeField] private float _wValue = 0.0f;

    private void OnGUI()
    {
        _wValue = GUI.HorizontalSlider(new Rect(Screen.width / 2 - 90, 10, 180, 20), _wValue, 0.0f, 1.0f);
        _hValue = GUI.VerticalSlider(new Rect(0, Screen.height / 2 - 150, 20, 300), _hValue, 1.0f, 0.0f);
    }
}
