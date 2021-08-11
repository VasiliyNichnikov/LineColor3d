using System;
using UnityEngine;

[Serializable]
public class MovementCarBack
{
    [SerializeField, Range(0, 20)] private float _stepZ;
    [SerializeField, Range(0, 1)] private float _reduceAnimation;
    [SerializeField] private AnimationCurve _yAnimation;

    private float _expiredTime;
    private float _duration = 1;

    private bool _isSavePosition;
    private Vector3 _endPosition;

    public void ResettingMovementCarBack()
    {
        _isSavePosition = false;
        _expiredTime = 0;
    }
    
    public float MovingBackwards(MovementCar movementCar)
    {
        Vector3 position = movementCar.Transform.position;
        if (!_isSavePosition)
        {
            _endPosition = new Vector3(position.x, position.y, position.z - _stepZ);
            _isSavePosition = true;
        }
        float progress = GettingProgress();
        
        movementCar.Transform.position = Vector3.MoveTowards(position, _endPosition, _yAnimation.Evaluate(progress) * _reduceAnimation);
        float distance = Vector3.Distance(position, _endPosition);
        return distance;
    }

    private float GettingProgress()
    {
        _expiredTime += Time.deltaTime;
        if (_expiredTime > _duration)
        {
            _expiredTime = 0;
        }

        return _expiredTime / _duration;
    }
    
}
