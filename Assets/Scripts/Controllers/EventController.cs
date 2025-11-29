using UnityEngine;
using System;
public static class EventController
{
    public static event Action StopMovement;
    public static event Action MatchWon;
    public static event Action MatchLost;
    public static event Action<float> FollowersUpdate;

    public static void StopMovementEvent()
    {
        StopMovement?.Invoke();
    }

    public static void MatchWonEvent()
    {
        MatchWon?.Invoke();
    }

    public static void MatchLostEvent()
    {
        MatchLost?.Invoke();
    }

    public static void FollowersUpdateEvent(float count)
    {
        FollowersUpdate?.Invoke(count);
    }
}   