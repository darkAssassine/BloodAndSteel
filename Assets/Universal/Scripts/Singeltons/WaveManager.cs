using System;
using UnityEngine;

public class WaveManager : MonoBehaviourSingleton<WaveManager>
{
    public int CurrentWave { get; private set; }


    protected void Awake()
    {
        base.Awake();
        PlayerPrefs.SetInt("WavesCleared", 1);
    }

    private void Start()
    {
        GameEvents.Instance.WaveCleared += OnWeaveCleared;
        CurrentWave = 1;
    }
    private void OnWeaveCleared(bool _)
    {
        ++CurrentWave;
    }

}
