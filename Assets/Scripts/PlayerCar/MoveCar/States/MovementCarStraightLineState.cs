using UnityEngine;

public class MovementCarStraightLineState : IMoveCarState
{
    public void ToRun(MovementCar movementCar)
    {
        float speed = movementCar.MovementForward.Speed;
        CheckingSpeed(movementCar, speed);
        Vector3 endPosition = movementCar.Positions.EndPosition;
        movementCar.Transform.position = Vector3.MoveTowards(movementCar.Transform.position, endPosition,
            speed * Time.deltaTime);
    }

    private void CheckingSpeed(MovementCar movementCar, float speed)
    {
        if (Mathf.Abs(movementCar.MovementForward.Max - speed) > 0.1f)
        {
            movementCar.MovementForward.ReducingSpeedMinimum(movementCar, movementCar.MovementForward.Max);
        }
        else
        {
            movementCar.MovementForward.Speed = movementCar.MovementForward.Max;
        }
    }
}