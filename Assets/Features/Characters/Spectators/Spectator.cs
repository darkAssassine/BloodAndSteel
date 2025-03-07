using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spectator : MonoBehaviour
{
    [SerializeField]
    Animator anim;

    private void Start()
    {
        if (GameEvents.Instance != null)
        {
            GameEvents.Instance.WaveCleared += PlayAnim;
        }
    }

    private void PlayAnim(bool playerWon)
    {
        if (playerWon)
        {
            anim.SetBool("PlayerWon", true);
        }
        else
        {
            anim.SetBool("PlayerLost", true);
        }
        StartCoroutine(Reset());
    }

    private IEnumerator Reset()
    {
        yield return new WaitForSeconds(2f);
        anim.SetBool("PlayerLost", false);
        anim.SetBool("PlayerWon", false);
    }
        
}

