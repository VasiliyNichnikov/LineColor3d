using System;

public static class EventManagerPlayerCar
{
    public static Action<int, float> EventSelectingAnimationAndStartTimeCar;
    public static Action EventGameOver;
    public static Action EventUpdateSizeBoxColliderAndShadow;
    public static Action EventUpdateSizeProjector;

    public static void CallSelectingAnimationCar(int index, float time)
    {
        EventSelectingAnimationAndStartTimeCar?.Invoke(index, time);
    }

    public static void CallUpdateSizeBoxColliderAndShadow()
    {
        EventUpdateSizeBoxColliderAndShadow?.Invoke();
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
