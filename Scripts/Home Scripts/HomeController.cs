using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeController : MonoBehaviour
{
    public GameObject SettingsPanelPopUp;

    private void Start()
    {
        SettingsPanelPopUp.SetActive(false);

        if (MusicSoundController.instance != null)
        {
            MusicSoundController.instance.MusicPlay(true);
        }

    }


    public void Play()
    {
        if (MusicSoundController.instance != null)
        {
            MusicSoundController.instance.ButtonClickSound();
        }

        SceneManager.LoadScene("Game");        
    }
    public void Settings()
    {
        if (MusicSoundController.instance != null)
        {
            MusicSoundController.instance.ButtonClickSound();
        }

        if (SettingsPanelPopUp != null)
            SettingsPanelPopUp.SetActive(true);
    }
    public void About()
    {
        if (MusicSoundController.instance != null)
        {
            MusicSoundController.instance.ButtonClickSound();
        }
    }
}
