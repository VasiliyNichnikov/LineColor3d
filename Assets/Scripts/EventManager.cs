﻿using System;

public static class EventManager
{
    public static Action<AnimationsType, float> EventSelectingAnimationCar;

    public static void CallSelectingAnimationCar(AnimationsType type, float time)
    {
        EventSelectingAnimationCar?.Invoke(type, time);
    }
}
