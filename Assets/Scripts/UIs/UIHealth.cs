using UnityEngine;
using UnityEngine.UI;

public class UIHealth : MonoBehaviour
{
    [Header("Interfaces")]
    [SerializeField] private Slider healthSlider;
    [SerializeField] private Image healthFiller;

    [Header("Color")]
    [SerializeField] private Gradient colorGradient;

    public void OnHealthChanged(float healthAmount)
    {
        healthSlider.value = healthAmount;

        healthFiller.color = colorGradient.Evaluate(healthSlider.normalizedValue);
    }

    public void OnHealthChanged(float currentHealth, float maxHealth)
    {
        float healthPercentage = currentHealth / maxHealth;
        healthSlider.value = healthPercentage;

        healthFiller.color = colorGradient.Evaluate(healthSlider.normalizedValue);
    }
}
