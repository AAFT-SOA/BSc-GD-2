using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUIController : MonoBehaviour
{
    public static GameUIController instance;

    public TextMeshProUGUI BulletCountsText;
    public TextMeshProUGUI GunStatusText;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Update()
    {
        EscapeGame();
    }


    public void UpdateBulletsCountUI(int _bullets)
    {
        BulletCountsText.text = _bullets.ToString();
    }
    public void UpdateGunStatusTextUI(string _msg)
    {
        GunStatusText.text = _msg;
    }

    public void EscapeGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Home");
        }

    }

}
