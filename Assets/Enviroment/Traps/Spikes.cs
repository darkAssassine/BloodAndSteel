using UnityEngine;

public class Spikes : MonoBehaviour
{
    [SerializeField]
    private int damage = 10;

    private void OnTriggerEnter(Collider other)
    {
        Health health = other.GetComponent<Health>();
        if (health != null )
            health.TakeDamage(damage);
    }
}
