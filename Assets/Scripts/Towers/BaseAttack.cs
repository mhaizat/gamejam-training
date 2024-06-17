using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAttack : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private StatsSO towerStat;

    [Header("Enemy")]
    [SerializeField] private BaseHealth targetHealth;

    private float coolDown = .0f;

    public bool CanAttack()
    {
        return coolDown <= .0f;
    }

    public bool SetHasTarget;
    private bool HasTarget() => SetHasTarget;

    private void Update()
    {
        if (HasTarget())
        {
            coolDown -= Time.deltaTime;
        }

        if (CanAttack())
        {
            DoAttack();
            coolDown = towerStat.attackCooldown;
        }
    }

    private void DoAttack()
    {
        if (HasTarget() && targetHealth != null)
        {
            float finalAttack = Random.Range(towerStat.attackMinimumPoint, towerStat.attackMaximumPoint);
            targetHealth.TakeDamage(finalAttack);
        }
    }

    public void SetAttackTarget(BaseHealth targetHealth)
    {
        this.targetHealth = targetHealth;
    }
}
