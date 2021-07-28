using System;

public static class EventManager
{
    public static Action<AnimationsType, float> EventSelectingAnimationCar;
    public static Action EventUpdateSizeBoxCollider;

    public static void CallSelectingAnimationCar(AnimationsType type, float time)
    {
        EventSelectingAnimationCar?.Invoke(type, time);
    }

    public static void CallUpdateSizeBoxCollider()
    {
        EventUpdateSizeBoxCollider?.Invoke();
    }
}
