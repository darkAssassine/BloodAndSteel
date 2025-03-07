using TMPro;
using UnityEngine;

public class WaveUI : MonoBehaviour
{
    Animator anim;

    [SerializeField]
    private TextMeshProUGUI tmpComponent;
    void Start()
    {
        anim = GetComponent<Animator>();
        GameEvents.Instance.WaveCleared += ShowCurrentWave;
    }

    private void ShowCurrentWave(bool _)
    {
        tmpComponent.text = $"Wave {PlayerPrefs.GetInt("WavesCleared")}";
        anim.Play("show_wave", -1, 0f);
        
    }
}
