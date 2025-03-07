using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{

    private int sum;

    private TextMeshProUGUI tmpComponent;
    private void OnEnable()
    {
     
        Time.timeScale = 0.2f;
    }

    private void OnDisable()
    {
        Time.timeScale = 1f;
    }

    public void ConfirmButtonPressed()
    {
        PlayerPrefs.SetInt("Glory", PlayerPrefs.GetInt("Glory") + sum);
        PlayerPrefs.SetInt("EnemysDefeated", 0);
        PlayerPrefs.SetInt("WavesCleared", 0);
        PlayerPrefs.SetInt("LevelsCleared", 0);
        sum = 0;
        SceneManager.LoadScene(0);
    }
}
