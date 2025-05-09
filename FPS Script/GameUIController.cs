using TMPro;
using UnityEngine;

public class GameUIController : MonoBehaviour
{
    public static GameUIController instance;

    public TextMeshProUGUI BulletCountsText;
    public TextMeshProUGUI GunStatusText;

    private void Awake()
    {
        if(instance == null)
            instance = this;
    }


    public void UpdateBulletsCountUI(int _bullets)
    {
        BulletCountsText.text = _bullets.ToString();
    }
    public void UpdateGunStatusTextUI(string _msg)
    {
        GunStatusText.text = _msg;
    }
}

