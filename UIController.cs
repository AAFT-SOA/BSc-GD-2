using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{

    public void PlayButton()
    {
        SceneManager.LoadSceneAsync("MainGame");
    }


    public void QuitGame()
    {
   
        Application.Quit();

    }

}
