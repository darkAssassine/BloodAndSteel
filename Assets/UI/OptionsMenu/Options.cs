using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    [SerializeField] 
    AudioMixer audioMixer;

    [SerializeField]
    private Slider masterSlider;

    [SerializeField]
    private Slider sfxSlider;

    [SerializeField]
    private Slider musicSlider;

    private void Start()
    {

        Load();
    }


    public void MasterSliderChanged(float value)
    {
        value = Mathf.Clamp(value, 0.0001f, 1);
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(value) * 20);
        PlayerPrefs.SetFloat("masterSliderValue", value);
    }

    public void SfxSliderChanged(float value)
    {
        value = Mathf.Clamp(value, 0.0001f, 1);
        audioMixer.SetFloat("sfxVolume", Mathf.Log10(value) * 20);
        PlayerPrefs.SetFloat("sfxSliderValue", value);
    }
    
    public void MusicSliderChanged(float value)
    {
        value = Mathf.Clamp(value, 0.0001f, 1);
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(value) * 20);
        PlayerPrefs.SetFloat("musicSliderValue", value);
    }

    private void Load()
    {
        masterSlider.value = PlayerPrefs.GetFloat("masterSliderValue",1);
        sfxSlider.value = PlayerPrefs.GetFloat("sfxSliderValue",1);
        musicSlider.value = PlayerPrefs.GetFloat("musicSliderValue", 1);

        MasterSliderChanged(PlayerPrefs.GetFloat("masterSliderValue", 1));
        SfxSliderChanged(PlayerPrefs.GetFloat("sfxSliderValue", 1));
        MusicSliderChanged(PlayerPrefs.GetFloat("musicSliderValue",1 ));
    }
}
