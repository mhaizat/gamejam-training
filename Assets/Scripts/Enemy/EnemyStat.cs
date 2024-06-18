using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStat : MonoBehaviour
{
    [SerializeField] private float enemyHealth;
    [SerializeField] private float enemyDefense;

    [SerializeField] private Slider enemyHealthBar;

    void Start()
    {
        SetEnemyHealth(enemyHealth);
    }

    void SetEnemyHealth(float health)
    {
        enemyHealthBar.maxValue = health;
        enemyHealthBar.value = health;
    }

    public void TakeDamage(float damage)
    {
        enemyHealth -= (damage - enemyDefense);
        enemyHealthBar.value = enemyHealth;

        if (enemyHealth <= 0)
        { 
            //!die
        }
    }
}
