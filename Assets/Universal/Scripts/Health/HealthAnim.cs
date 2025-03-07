using UnityEngine;


[RequireComponent(typeof(HealthEvent))]
public class HealthAnim : MonoBehaviour
{
    private HealthEvent healthEvent;


    [SerializeField, Header("Animation")]
    public Animator anim;

    [SerializeField]
    private string hitAnim = "";

    [SerializeField]
    private string deathAnim = "";

    [SerializeField]
    private string healAnim = "";

    private void Start()
    {
        
        healthEvent = GetComponent<HealthEvent>();
        healthEvent.OnHeal += PlayHealAnim;
        healthEvent.OnDeath += PlayDeathAnim;
        healthEvent.OnHit += PlayTakeDamageAnim;
    }

    private void PlayTakeDamageAnim()
    {
     
        if ( anim != null )
        {
            anim.Play(hitAnim);
            
        }   
    }

    private void PlayHealAnim()
    {
        if (anim != null)
        {
            anim.Play(healAnim);
        }
    }

    private void PlayDeathAnim()
    {
        if (anim != null)
        {
            anim.Play(deathAnim);
        }
    }
}
