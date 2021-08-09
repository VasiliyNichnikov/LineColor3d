using System;

public static class EventManagerPlayerCar
{
    public static Action<AnimationsType, float> EventSelectingAnimationAndStartTimeCar;
    public static Action EventGameOver;
    public static Action EventUpdateSizeBoxCollider;
    public static Action EventUpdateSizeProjector;

    public static void CallSelectingAnimationCar(AnimationsType type, float time)
    {
        EventSelectingAnimationAndStartTimeCar?.Invoke(type, time);
    }

    public static void CallUpdateSizeBoxCollider()
    {
        EventUpdateSizeBoxCollider?.Invoke();
    }
    
    public static void CallUpdateSizeProjector()
    {
        EventUpdateSizeProjector?.Invoke();
    }

    public static void CallGameOver()
    {
        EventGameOver?.Invoke();
    }
}
