using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverActualNumbers : MonoBehaviour
{


    private int sum;

    private TextMeshProUGUI tmpComponent;
    private void OnEnable()
    {
        tmpComponent = GetComponent<TextMeshProUGUI>();

        sum = Mathf.RoundToInt((Mathf.RoundToInt((PlayerPrefs.GetInt("EnemysDefeated") + PlayerPrefs.GetInt("WavesCleared")-1) * 7) + PlayerPrefs.GetInt("WavesCleared") + PlayerPrefs.GetInt("EnemysDefeated")));

        tmpComponent.text = $"{Mathf.RoundToInt((PlayerPrefs.GetInt("EnemysDefeated")+ PlayerPrefs.GetInt("WavesCleared")-1) * 7)}  \n" +
        $"{PlayerPrefs.GetInt("WavesCleared")-1} \n" +
        $"{PlayerPrefs.GetInt("EnemysDefeated")}";

        Time.timeScale = 0.2f;
    }
}
