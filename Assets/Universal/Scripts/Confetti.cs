using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Confetti : MonoBehaviour
{
    [SerializeField]
    private GameObject confetti;

    [SerializeField]
    private Transform[] confettiPos;
    void Start()
    {
        GameEvents.Instance.WaveCleared += PlayConfetti;
    }


    private void PlayConfetti(bool playerWon) 
    { 
        if (playerWon)
        {
            for (int i = 0; i < confettiPos.Length; i++)
            {
                Destroy(Instantiate(confetti, confettiPos[i].position, confettiPos[i].rotation), 5f);
            }
        }
     
    }

}
