using System;

public static class EventManagerPlayerCar
{
    public static Action<AnimationsType, float> EventSelectingAnimationCar;
    public static Action EventUpdateSizeBoxCollider;
    public static Action EventUpdateSizeProjector;

    public static void CallSelectingAnimationCar(AnimationsType type, float time)
    {
        EventSelectingAnimationCar?.Invoke(type, time);
    }

    public static void CallUpdateSizeBoxCollider()
    {
        EventUpdateSizeBoxCollider?.Invoke();
    }
    
    public static void CallUpdateSizeProjector()
    {
        EventUpdateSizeProjector?.Invoke();
    }
}
