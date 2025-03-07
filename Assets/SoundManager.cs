using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip buttonSound;

    public void ButtonSound()
    {
        audioSource.clip = buttonSound;     
        audioSource.Play();
    }
}
