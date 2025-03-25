using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    public TextMeshProUGUI TargetValue, ScoreValue;

    public GameObject LevelCompletePopUp;
    public TextMeshProUGUI LC_ScoreValue;

    public GameObject LevelFailedPopUp;
    public TextMeshProUGUI LF_ScoreValue;

    public bool IsLevelFailed;

    public int Target;
    int Score;

    public GameObject PausePopUp;


    public bool IsAnyPopupOpened;

    private void Awake()
    {
        if(instance == null)
            instance = this;
    }

    private void Start()
    {
        Initialize();
    }

    void Initialize()
    {        
        UpdateTargetUI();

        Score = 0;
        ScoreValue.text = Score.ToString();

        LevelCompletePopUp.SetActive(false);
        LevelFailedPopUp.SetActive(false);

        IsLevelFailed = false;
        IsAnyPopupOpened = false;
    }

    void UpdateTargetUI()
    {
        TargetValue.text = Target.ToString();
    }


    public void AddScore(int value)
    {        
        Score = Score + value;
        ScoreValue.text = Score.ToString();

        // Check Level Complete
        if(Score == Target)
        {
            StartCoroutine(WaitToOpenLevelCompletePopUp());
        }

    }
    


    #region LevelCompletePopUp
    IEnumerator WaitToOpenLevelCompletePopUp()
    {
        yield return new WaitForSeconds(1f);
        // Open Level Complete PopUp
        LevelCompletePopUp.SetActive(true);
        LC_ScoreValue.text = Score.ToString();

        IsAnyPopupOpened = true;
        UnityEngine.Cursor.visible = true;
    }

    public void LevelCompletePopUp_Restart()
    {
        if (MusicSoundController.instance != null)
        {
            MusicSoundController.instance.ButtonClickSound();
        }

        LevelCompletePopUp.SetActive(false);

        SceneManager.LoadScene("Game");

        IsAnyPopupOpened = false;
    }
    public void LevelCompletePopUp_Home()
    {
        if (MusicSoundController.instance != null)
        {
            MusicSoundController.instance.ButtonClickSound();
        }

        LevelCompletePopUp.SetActive(false);

        SceneManager.LoadScene("Home");

        IsAnyPopupOpened = false;
    }
    public void LevelCompletePopUp_Next()
    {
        if (MusicSoundController.instance != null)
        {
            MusicSoundController.instance.ButtonClickSound();
        }

        LevelCompletePopUp.SetActive(false);

        IsAnyPopupOpened = false;
    }
    #endregion


    #region LevelFailedPopUp
    public void OpenLevelFailedPopUp()
    {
        StartCoroutine(WaitToOpenLevelFailedPopUp());
    }

    IEnumerator WaitToOpenLevelFailedPopUp()
    {
        yield return new WaitForSeconds(1f);
        // Open Level Complete PopUp
        LevelFailedPopUp.SetActive(true);
        LF_ScoreValue.text = Score.ToString();

        IsLevelFailed = true;

        IsAnyPopupOpened = true;
        UnityEngine.Cursor.visible = true;
    }
    public void LevelFailedPopUp_Restart()
    {
        if (MusicSoundController.instance != null)
        {
            MusicSoundController.instance.ButtonClickSound();
        }

        LevelFailedPopUp.SetActive(false);

        SceneManager.LoadScene("Game");

        IsAnyPopupOpened = false;
    }
    public void LevelFailedPopUp_Home()
    {
        if (MusicSoundController.instance != null)
        {
            MusicSoundController.instance.ButtonClickSound();
        }

        LevelFailedPopUp.SetActive(false);

        SceneManager.LoadScene("Home");

        IsAnyPopupOpened = false;
    }
    #endregion


    #region PausePopUp
    public void PauseButtonClick()
    {
        if (MusicSoundController.instance != null)
        {
            MusicSoundController.instance.ButtonClickSound();
        }
               

        // Open Pause PopUp
        PausePopUp.SetActive(true);

        IsAnyPopupOpened = true;
        UnityEngine.Cursor.visible = true;

        Time.timeScale = 0;
    }
    
    public void Pause_ResumeClick()
    {
        if (MusicSoundController.instance != null)
        {
            MusicSoundController.instance.ButtonClickSound();
        }

        Time.timeScale = 1;
        PausePopUp.SetActive(false);

        IsAnyPopupOpened = false;
    }

    public void Pause_HomeClick()
    {
        if (MusicSoundController.instance != null)
        {
            MusicSoundController.instance.ButtonClickSound();
        }

        Time.timeScale = 1;
        PausePopUp.SetActive(false);
        SceneManager.LoadScene("Home");

        IsAnyPopupOpened = false;
    }
    #endregion
}
