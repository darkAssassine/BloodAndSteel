using UnityEngine;
using TMPro;
using System.Transactions;

public class WaveTimer : MonoBehaviour
{
    private TextMeshProUGUI timerGUI;

    [SerializeField]
    private AnimationCurve baseTime;

    [SerializeField]
    private AnimationCurve timeBoni;

    private float time;
    private bool hasStarted;


    void Start()
    {
        timerGUI = GetComponent<TextMeshProUGUI>(); 
        GameEvents.Instance.WaveCleared += ResetTimer;
        time = Mathf.RoundToInt(baseTime.Evaluate(PlayerPrefs.GetInt("WavesCleared")));
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);

        timerGUI.text = $"{minutes:00} : {seconds:00}";
        time = 0;
    }

    void Update()
    {
        if (hasStarted == false)
             return;
        time -= Time.deltaTime;
        if (time <= 0)
        {
            int currentWave = PlayerPrefs.GetInt("WavesCleared");
            PlayerPrefs.SetInt("WavesCleared", currentWave +1); 
            GameEvents.Instance.WaveCleared.Invoke(false);
        }

        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);

        timerGUI.text = $"{minutes:00} : {seconds:00}";

    }

    private void ResetTimer(bool _)
    {
        hasStarted = true;
        GetComponent<Animator>().Play("blink", -1, 0);
        time += Mathf.RoundToInt(baseTime.Evaluate(PlayerPrefs.GetInt("WavesCleared"))) + Mathf.RoundToInt(timeBoni.Evaluate(PlayerPrefs.GetInt("WavesCleared")));   
    }
}
