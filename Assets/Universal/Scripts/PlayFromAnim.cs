using UnityEngine;
using UnityEngine.VFX;
public class PlayFromAnim : MonoBehaviour
{
    [SerializeField]
    private PlayRandomSound[] randomSounds;

    [SerializeField] private AudioSource[] sounds;

    [SerializeField]
    private ParticleSystem[] particles;

    [SerializeField]
    private VisualEffect[] graphs;

    public void PlaySound(int index)
    {
        sounds[index].Play();
    }

    public void PlayRandomSound(int index)
    {
        randomSounds[index].Play();
    }

    public void PlayGraph(int index)
    { 
        graphs[index].Play(); 
    }

    public void PlayParticle(int index)
    {
        particles[index].Play();
    }
}
