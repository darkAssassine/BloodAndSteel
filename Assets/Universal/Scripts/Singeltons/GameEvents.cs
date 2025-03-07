using System;
using UnityEngine;

public class GameEvents : MonoBehaviourSingleton<GameEvents>
{
    public Action PlayerDied;
    public Action<bool> WaveCleared;
    public Action LevelCleared;
    public Action<AnimationCurve> Screenshake;

    public Action OnPause;
    public Action OnResume;

    public void Pause()
    {
        Time.timeScale = 0.0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if (OnResume != null )
            OnPause.Invoke();
    }

    public void Resume()
    {
        Time.timeScale = 1.0f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        if (OnResume != null)
         OnResume.Invoke();
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("EnemysDefeated", 0);
        PlayerPrefs.SetInt("WavesCleared", 0);
        PlayerPrefs.SetInt("LevelsCleared", 0);
    }
}
