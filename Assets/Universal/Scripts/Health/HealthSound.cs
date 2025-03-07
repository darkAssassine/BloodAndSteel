using UnityEngine;

[RequireComponent(typeof(HealthEvent))]
public class HealthSound : MonoBehaviour
{
    private HealthEvent healthEvent;

    [SerializeField, Header("SFX")]
    private PlayRandomSound[] hitSounds;

    [SerializeField]
    private PlayRandomSound[] deathSounds;

    [SerializeField]
    private PlayRandomSound[] healingSounds;


    private void Start()
    {

        healthEvent = GetComponent<HealthEvent>();
        healthEvent.OnHeal += PlayHealSound;
        healthEvent.OnDeath += PlayDeathSound;
        healthEvent.OnHit += PlayTakeDamageSound;
    }

    private void PlayTakeDamageSound()
    {
        if (hitSounds != null && hitSounds.Length > 0)
            hitSounds[Random.Range(0, hitSounds.Length)]?.Play();
    }

    private void PlayHealSound()
    {
        if (healingSounds != null && healingSounds.Length > 0)
            healingSounds[Random.Range(0, healingSounds.Length)].Play();
    }

    private void PlayDeathSound()
    {
        if (deathSounds != null && deathSounds.Length > 0)
            deathSounds[Random.Range(0, deathSounds.Length)].Play();
    }
}
