using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    public GameObject SettingsPanelPopUp;
    public Slider MusicSlider, SoundSlider;



    private void Awake()
    {
        LoadDataFromPlayerPrefs();
    }


    void LoadDataFromPlayerPrefs()
    {
        if(MusicSlider != null)
            MusicSlider.value = PlayerPrefs.GetFloat("MUSIC");

        if(SoundSlider != null)
            SoundSlider.value = PlayerPrefs.GetFloat("SOUND");
    }



    public void SettingsPanelPopUp_Close()
    {
        if (MusicSoundController.instance != null)
        {
            MusicSoundController.instance.ButtonClickSound();
        }

        SettingsPanelPopUp.SetActive(false);
    }

    public void MusicSliderValue()
    {
        Debug.Log("MusicSlider Value = " + MusicSlider.value);
        if (MusicSoundController.instance != null)
        {
            MusicSoundController.instance.MusicSliderValueChanged(MusicSlider.value);
        }
    }

    public void SoundSliderValue()
    {
        Debug.Log("SoundSlider Value = " + SoundSlider.value);
        if (MusicSoundController.instance != null)
        {
            MusicSoundController.instance.SoundSliderValueChanged(SoundSlider.value);
        }
    }
}
