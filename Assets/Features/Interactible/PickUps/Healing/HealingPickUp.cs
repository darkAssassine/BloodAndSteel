using UnityEngine;
using UnityEngine.VFX;

public class HealingPickUp : MonoBehaviour
{
    [SerializeField]
    private float healAmountInProz;

    [SerializeField]
    private VisualEffect healGraph;

    [SerializeField]
    private ParticleSystem healVFX;

    [SerializeField]
    private float destroyTime = 1f;

    private bool isUsed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isUsed)
        {
            if (other.GetComponent<Health>().CurrentHp != other.GetComponent<Health>().MaxHp)
            {

                Health playerHealth = other.GetComponent<Health>();
                healAmountInProz = playerHealth.MaxHp * (healAmountInProz / 100);
                playerHealth.Heal((int)healAmountInProz);
                if (healGraph != null)
                    healGraph.Play();
                if (healVFX != null)
                    healVFX?.Play();
                isUsed = true;
                Destroy(this.gameObject, destroyTime);
            }
        } 
    }
}
