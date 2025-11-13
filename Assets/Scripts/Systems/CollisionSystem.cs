using UnityEngine;
using UnityEngine.Events;


public class CollisionSystem : MonoBehaviour
{
    public UnityEvent<GameObject, GameObject> Collided;
    public UnityEvent<GameObject, GameObject> Triggered;
    public UnityEvent<GameObject, GameObject> CollidedExit;

    private GameObject myself;

    void Start()
    {
        myself = this.gameObject;
    }

    void OnCollisionEnter(Collision collision)
    {
        Collided.Invoke(myself, collision.gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        Triggered.Invoke(myself, other.gameObject);
    }

    void OnCollisionExit(Collision collision)
    {
        CollidedExit.Invoke(myself, collision.gameObject);
    }
}
