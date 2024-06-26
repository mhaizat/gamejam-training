using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BaseHealth : MonoBehaviour, IDamageable
{
    public StatsSO healthStat;

    [Header("Stats")]
    [SerializeField] private float currentHealth;
    [SerializeField] private float maxHealth;

    [Header("Events")]
    public UnityEvent OnHealthChange;
    public UnityEvent<float> OnHealthChangeValue;
    public UnityEvent OnDeathEvent;

    private void Start()
    {
        if (healthStat != null)
        {
            maxHealth = healthStat.healthPoint;
            currentHealth = maxHealth;

            OnHealthChange?.Invoke();
            OnHealthChangeValue?.Invoke(currentHealth);
        }
        else
        {
            Debug.LogWarning($"{gameObject.name}'s Health Stat field is empty");
        }
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;

        OnHealthChange?.Invoke();
        OnHealthChangeValue?.Invoke(currentHealth);

        if (currentHealth <= 0)
        {
            Death();
        }
    }

    public void HealDamage(float amount)
    {
        currentHealth += amount;

        OnHealthChange?.Invoke();
        OnHealthChangeValue?.Invoke(currentHealth);

        if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public void Death()
    {
        OnDeathEvent?.Invoke();
    }
}
