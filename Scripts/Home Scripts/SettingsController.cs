using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    public GameObject SettingsPanelPopUp;
    public Slider MusicSlider, SoundSlider;

    public Image SoundButtonImage, MusicButtonImage;
    public Sprite SoundOn, SoundOff;
    public Sprite MusicOn, MusicOff;


    private void Awake()
    {
        LoadDataFromPlayerPrefs();        
    }


    void LoadDataFromPlayerPrefs()
    {
        if (MusicSlider != null)
        {
            MusicSlider.value = PlayerPrefs.GetFloat("MUSIC");

            // Sound Button Image Change
            if (MusicSlider.value > 0f)
            {
                MusicButtonImage.sprite = MusicOn;
            }
            else
            {
                MusicButtonImage.sprite = MusicOff;
            }
        }

        if (SoundSlider != null)
        {
            SoundSlider.value = PlayerPrefs.GetFloat("SOUND");

            // Sound Button Image Change
            if (SoundSlider.value > 0f)
            {
                SoundButtonImage.sprite = SoundOn;
            }
            else
            {
                SoundButtonImage.sprite = SoundOff;
            }

        }
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
            MusicSoundController.instance.MusicSourceValueChanged(MusicSlider.value);
        
        MusicButtonImageOnOff();
    }

    public void SoundSliderValue()
    {
        Debug.Log("SoundSlider Value = " + SoundSlider.value);
        if (MusicSoundController.instance != null)        
            MusicSoundController.instance.SoundSourceValueChanged(SoundSlider.value);        

        SoundButtonImageOnOff();
    }

    void MusicButtonImageOnOff()
    {
        if (MusicSlider != null)
        {
            // Music Button Image Change
            if (MusicSlider.value > 0f)
            {
                MusicButtonImage.sprite = MusicOn;
            }
            else
            {
                MusicButtonImage.sprite = MusicOff;
            }
        }
    }
    void SoundButtonImageOnOff()
    {
        if (SoundSlider != null)
        {
            // Sound Button Image Change
            if (SoundSlider.value > 0f)
            {
                SoundButtonImage.sprite = SoundOn;
            }
            else
            {
                SoundButtonImage.sprite = SoundOff;
            }
        }
    }









    public void MusicButtonClick()
    {
        Debug.Log("MusicButtonClick............    " + PlayerPrefs.GetFloat("MUSIC"));

        if(PlayerPrefs.GetFloat("MUSIC") > 0f)
        {
            Debug.Log("MusicOff,,,,,,,,,");
            // Stop Music
            MusicButtonImage.sprite = MusicOff;

            if (MusicSoundController.instance != null)
            {
                MusicSoundController.instance.MusicSourceValueChanged(0);
                MusicSlider.value = 0f;
            }
        }
        else
        {
            Debug.Log("MusicOn,,,,,,,,,");
            // Start Music
            MusicButtonImage.sprite = MusicOn;

            if (MusicSoundController.instance != null)
            {
                MusicSoundController.instance.MusicSourceValueChanged(1);

                MusicSlider.value = 1f;
            }
        }
    }
    public void SoundButtonClick()
    {        
        Debug.Log("SoundButtonClick............    " + PlayerPrefs.GetFloat("SOUND"));

        if (PlayerPrefs.GetFloat("SOUND") > 0f)
        {
            Debug.Log("SoundOff,,,,,,,,,");
            // Stop Music
            SoundButtonImage.sprite = SoundOff;

            if (MusicSoundController.instance != null)
            {
                MusicSoundController.instance.SoundSourceValueChanged(0);

                SoundSlider.value = 0;
            }
        }
        else
        {
            Debug.Log("SoundOn,,,,,,,,,");
            // Start Music
            SoundButtonImage.sprite = SoundOn;

            if (MusicSoundController.instance != null)
            {
                MusicSoundController.instance.SoundSourceValueChanged(1);

                SoundSlider.value = 1;
            }
        }
    }
}
