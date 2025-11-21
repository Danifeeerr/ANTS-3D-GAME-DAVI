using UnityEngine;
using System;
public static class EventController
{
    public static event Action StopMovement;
    public static event Action<GameObject> ObstacleTouched;

    public static void StopMovementEvent()
    {
        StopMovement?.Invoke();
    }
    public static void ObstacleTouchedEvent(GameObject ant)
    {
        ObstacleTouched?.Invoke(ant);
    }
}
