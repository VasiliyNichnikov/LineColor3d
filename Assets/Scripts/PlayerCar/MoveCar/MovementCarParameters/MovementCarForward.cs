using System;
using UnityEngine;


[Serializable]
public class MovementCarForward
{
    public float Speed
    {
        get => _speed;
        set
        {
            if (value >= 0) _speed = value;
        }
    }
    public float Min => min;
    public float Max => max;
    
    [SerializeField] private float min;
    [SerializeField] private float max;
    [SerializeField, Range(0, 20)]private float _speedAnimation;
    [SerializeField]private float _speed;
    
    public void ReducingSpeedMinimum(MovementCar movementCar, float speedEnd)
    {
        float speed = movementCar.MovementForward.Speed;
        movementCar.MovementForward.Speed = Mathf.Lerp(speed, speedEnd, _speedAnimation * Time.deltaTime);
    }
}
