using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class BaseAttack : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private StatsSO towerStat;

    [Header("Enemy")]
    [SerializeField] private BaseHealth targetHealth;

    [SerializeField] private float coolDown = .0f;

    [Header("Unity Event")]
    public UnityEvent OnTargetDeath;

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
            if(targetHealth.gameObject.activeInHierarchy)
            {
                float finalAttack = Random.Range(towerStat.attackMinimumPoint, towerStat.attackMaximumPoint);
                targetHealth.TakeDamage(finalAttack);
            }
            else
            {
                StopAttack();
            }
        }
        
        if(targetHealth == null)
        {
            //! Optional to remove this line
            // Debug.Log("No target health is found");
        }
    }

    public void StopAttack()
    {
        SetHasTarget = false;
        coolDown = towerStat.attackCooldown;

        OnTargetDeath?.Invoke();
        if (targetHealth != null && targetHealth.OnDeathEvent != null)
        {
            targetHealth.OnDeathEvent.RemoveListener(StopAttack);
        }
        
        SetAttackTarget(null);
    }

    public void SetAttackTarget(BaseHealth targetHealth)
    {
        if (this.targetHealth != null)
        {
            this.targetHealth.OnDeathEvent.RemoveListener(StopAttack);
        }

        this.targetHealth = targetHealth;
        if (targetHealth != null)
        {
            targetHealth.OnDeathEvent.AddListener(StopAttack);
        }
    }
}
