using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdCheering : MonoBehaviour
{
    [SerializeField]
    private PlayRandomSound cheerSound;
    private void Start()
    {
        if (GameEvents.Instance != null)
        {
            GameEvents.Instance.WaveCleared += Cheer;
        }
    }

    private void Cheer(bool playerWon)
    {
        if (playerWon)
        {
            cheerSound.Play();
        }

    }
}
