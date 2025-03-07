using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLoseUI : MonoBehaviour
{

    [SerializeField]
    GameObject losingScreen;

    private void Start()
    {
        losingScreen.SetActive(false);
        GameEvents.Instance.PlayerDied += ShowLosingScreen;
    }

    private void ShowLosingScreen()
    {
        losingScreen.SetActive(true);
    }
}
