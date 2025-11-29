
using UnityEngine;


public class DamageSystem : MonoBehaviour
{
    public float damage = 1.0f;

    private void OnEnable()
    {
        this.TryGetComponent<CollisionSystem>(out CollisionSystem cs);
        if (cs != null)
        {
            cs.ActCollided += DoDamage;
            cs.ActTriggered += DoDamage;
        }
    }

    private void OnDisable()
    {
        this.TryGetComponent<CollisionSystem>(out CollisionSystem cs);
        if (cs != null)
        {
            cs.ActCollided -= DoDamage;
            cs.ActTriggered -= DoDamage;
        }
    }

    public void DoDamage(GameObject other){
        if (other.TryGetComponent<HealthSystem>(out HealthSystem hs))
        {
            hs.Hurt(damage);
        }
    }
}