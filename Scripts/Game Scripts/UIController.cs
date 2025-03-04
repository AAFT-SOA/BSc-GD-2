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
    }

    public void LevelCompletePopUp_Restart()
    {
        LevelCompletePopUp.SetActive(false);

        SceneManager.LoadScene("Game");
    }
    public void LevelCompletePopUp_Home()
    {
        LevelCompletePopUp.SetActive(false);

        SceneManager.LoadScene("Home");
    }
    public void LevelCompletePopUp_Next()
    {
        LevelCompletePopUp.SetActive(false);
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
    }
    public void LevelFailedPopUp_Restart()
    {
        LevelFailedPopUp.SetActive(false);

        SceneManager.LoadScene("Game");
    }
    public void LevelFailedPopUp_Home()
    {
        LevelFailedPopUp.SetActive(false);

        SceneManager.LoadScene("Home");
    }
    #endregion


    #region PausePopUp
    public void PauseButtonClick()
    {
        // Open Pause PopUp
        PausePopUp.SetActive(true);
        Time.timeScale = 0;
    }
    
    public void Pause_ResumeClick()
    {
        Time.timeScale = 1;
        PausePopUp.SetActive(false);
        
    }

    public void Pause_HomeClick()
    {
        Time.timeScale = 1;
        PausePopUp.SetActive(false);
        SceneManager.LoadScene("Home");
    }
    #endregion
}
