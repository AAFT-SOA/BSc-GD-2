using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public static EnemyHealthBar instance;

    Image healthBarFill;


    private void Awake()
    {
        if(instance == null )
            instance = this;
    }

    private void Start()
    {
        healthBarFill = GetComponent<Image>();
    }

    public void UpdateHealthBar(float currentHealth,float maxHealth)
    {
        healthBarFill.fillAmount = currentHealth/maxHealth;
    }

}
