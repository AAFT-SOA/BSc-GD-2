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
    }


    public void Play()
    {
        SceneManager.LoadScene("Game");
    }
    public void Settings()
    {
        if(SettingsPanelPopUp != null)
            SettingsPanelPopUp.SetActive(true);
    }
    public void About()
    {

    }
}
