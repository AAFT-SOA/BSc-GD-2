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

    int Target;
    int Score;


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
        Target = 7;
        UpdateTargetUI();

        Score = 0;
    }

    void UpdateTargetUI()
    {
        TargetValue.text = Target.ToString();
    }


    public void AddScore()
    {        
        Score = Score + 1;
        ScoreValue.text = Score.ToString();
    }




    public void BackButtonClick()
    {
        SceneManager.LoadScene("Home");
    }
}
