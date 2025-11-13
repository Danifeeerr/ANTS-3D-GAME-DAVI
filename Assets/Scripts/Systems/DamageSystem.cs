
using UnityEngine;


public class DamageSystem : MonoBehaviour
{
    public float damage = 1.0f;

    public void DoDamage(GameObject other, GameObject myself){
        if (other.TryGetComponent<HealthSystem>(out HealthSystem hs) && myself == this.gameObject)
        {
            hs.Hurt(damage);
        }
    }
}