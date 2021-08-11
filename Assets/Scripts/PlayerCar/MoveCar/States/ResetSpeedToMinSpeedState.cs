public class ResetSpeedToMinSpeedState: IMoveCarState
{
    public void ToRun(MovementCar movementCar)
    {
        movementCar.MovementForward.Speed = movementCar.MovementForward.Min;
        movementCar.MovementForward.ReducingSpeedMinimum(movementCar, movementCar.MovementForward.Min);
        float distance = movementCar.MovementBack.MovingBackwards(movementCar);
        if (!(distance < 0.1f)) return;
        movementCar.MovementBack.ResettingMovementCarBack();
        movementCar.SetState(new MovementCarStraightLineState());
    }
}