public class AcceleratorCarForwardState : IMoveCarState
{
    public void ToRun(MovementCar movementCar)
    {
        float speedMax = movementCar.MovementForward.Max;
        movementCar.MovementForward.Speed = speedMax;
        movementCar.SetState(new MovementCarStraightLineState());
    }
}