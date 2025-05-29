using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    public static PlayerHealthBar instance;

    Image healthBarFill;


    private void Awake()
    {
        if(instance == null)
            instance = this;
    }

    private void Start()
    {
        healthBarFill = GetComponent<Image>();
    }

    public void UpdateHealthBar(float currentHealth,float maxHealth)
    {
        if(healthBarFill != null)
        {
            healthBarFill.fillAmount = currentHealth/maxHealth;
        }
    }

}
