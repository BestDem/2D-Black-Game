using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{   
    [SerializeField] private Image healthBar;
    public void HealthMagDamage(float maxHealth, float currentHealth)
    {
        healthBar.fillAmount = currentHealth / maxHealth;
    }
}
