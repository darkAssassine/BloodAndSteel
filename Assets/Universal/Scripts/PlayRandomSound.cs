using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayRandomSound : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip[] clips;

    [SerializeField]
    private bool PlayOnStart;

    [SerializeField]
    private bool autoPlayNext;

    private bool shouldPlayNext = false;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayOnStart)
            Play();

    }

    // Update is called once per frame
    void Update()
    {
        if (autoPlayNext && shouldPlayNext && audioSource.isPlaying == false)
        {
            Play();
            Debug.Log("shit");
        }  
    }

    public void Play()
    {
        shouldPlayNext = true;
        audioSource.clip = clips[Random.Range(0, clips.Length)];
        audioSource.Play();
    }

    public void Stop()
    {
        shouldPlayNext = false ;
        audioSource.Stop();
    }



    
}
