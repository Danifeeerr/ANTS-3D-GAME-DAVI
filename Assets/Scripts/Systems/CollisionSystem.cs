using UnityEngine;
using UnityEngine.Events;
using System;


public class CollisionSystem : MonoBehaviour
{
    public UnityEvent<GameObject> Collided;
    public UnityEvent<GameObject> Triggered;
    public UnityEvent<GameObject> CollidedExit;
    public event Action<GameObject> ActTriggered;
    public event Action<GameObject> ActCollided;


    private GameObject myself;

    void Start()
    {
        myself = this.gameObject;
    }

    void OnCollisionEnter(Collision collision)
    {
        Collided?.Invoke(collision.gameObject);
        ActCollided?.Invoke(collision.gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        Triggered?.Invoke(other.gameObject);
        ActTriggered?.Invoke(other.gameObject);
    }

    void OnCollisionExit(Collision collision)
    {
        CollidedExit?.Invoke(collision.gameObject);
    }
}
