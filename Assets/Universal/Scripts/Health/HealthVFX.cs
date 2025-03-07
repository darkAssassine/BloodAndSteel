using UnityEngine;
using UnityEngine.VFX;

[RequireComponent(typeof(HealthEvent))]
public class HealthVFX : MonoBehaviour
{
    private HealthEvent healthEvent;

    [SerializeField, Header("VFX")]
    private ParticleSystem[] hitVFX;

    [SerializeField]
    private ParticleSystem[] deathVFX;

    [SerializeField]
    private ParticleSystem[] healVFX;

    [SerializeField, Header("Graph")]
    private VisualEffect[] hitGraph;

    [SerializeField]
    private VisualEffect[] deathGraph;

    [SerializeField]
    private VisualEffect[] healGraph;

    [SerializeField]
    private GameObject[] hitPrefabs;

    [SerializeField]
    private GameObject[] deathPrefabs;

    [SerializeField]
    private GameObject[] healPrefabs;

    private void Start()
    {

        healthEvent = GetComponent<HealthEvent>();
        healthEvent.OnHeal += PlayHealVFX;
        healthEvent.OnDeath += PlayDeathVFX;
        healthEvent.OnHit += PlayTakeDamageVFX;
    }

    private void PlayVFX(ParticleSystem[] ps, VisualEffect[] vfx, GameObject[] pref)
    {

        for (int i = 0; i < vfx.Length; i++)
        {
            if (vfx[i] != null)
                vfx[i].Play();
        }


        for (int i = 0; i < ps.Length; i++)
        {
            if (ps[i] != null)
                ps[i].Play();
        }

        for (int i = 0; i < pref.Length; i++)
        {
            if (pref[i] != null)
                Destroy(Instantiate(pref[i], transform.position, transform.rotation),1);
        }
    }

    private void PlayTakeDamageVFX()
    {

         PlayVFX(hitVFX, hitGraph, hitPrefabs);
        
    }

    private void PlayHealVFX()
    {
        PlayVFX(healVFX, healGraph, deathPrefabs);
    }

    private void PlayDeathVFX()
    {
        PlayVFX(deathVFX, deathGraph, healPrefabs);
    }
}
