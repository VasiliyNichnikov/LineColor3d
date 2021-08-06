using UnityEngine;

public class CalculatorTimeAnimation
{
    public float TimeX { get; private set; } = 0.0f;
    public float TimeY { get; private set; } = 0.0f;

    public float SaveTimeX => _saveTimeX;
    public float SaveTimeY => _saveTimeY;
    
    private float _saveTimeX = 0.0f, _saveTimeY = 0.0f;

    public void ChangingValuesTimeXAndTimeY(Vector2 direction)
    {
        TimeX = Mathf.Clamp01(_saveTimeX + direction.x);
        TimeY = Mathf.Clamp01(_saveTimeY + direction.y);
    }

    public void ResetingSaveTimeXAndSaveTimeY()
    {
        _saveTimeX = TimeX;
        _saveTimeY = TimeY;
    }
    
}
