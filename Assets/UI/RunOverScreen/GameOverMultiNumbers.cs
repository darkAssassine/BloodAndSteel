using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameOverMultiNumbers : MonoBehaviour
{
    [SerializeField, Header("Glory pro:")]
    private float caloriesBurned;

    [SerializeField]
    private int weaves;

    [SerializeField]
    private int kills;

    private int sum;
    private TextMeshProUGUI tmpComponent;
    private void OnEnable()
    {
        tmpComponent = GetComponent<TextMeshProUGUI>();

        sum = Mathf.RoundToInt(Mathf.RoundToInt(((PlayerPrefs.GetInt("EnemysDefeated") + PlayerPrefs.GetInt("WavesCleared")-1) * 7) * caloriesBurned) + PlayerPrefs.GetInt("WavesCleared") * weaves + PlayerPrefs.GetInt("EnemysCleared") * kills);


        tmpComponent.text = $"{Mathf.RoundToInt(((PlayerPrefs.GetInt("EnemysDefeated") + PlayerPrefs.GetInt("WavesCleared")-1) * 7) * caloriesBurned)} \n" +
        $"{(PlayerPrefs.GetInt("WavesCleared") - 1) * weaves}\n" +
        $"{PlayerPrefs.GetInt("EnemysDefeated") * kills}\n \n {sum}";
  

        Time.timeScale = 0.2f;
    }
}
