using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTower : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private StatsSO towerStat;
    [SerializeField] private BaseSensor towerSensor;
    [SerializeField] private BaseHealth towerHealth;
    [SerializeField] private BaseAttack towerAttack;

    [Header("Visual")]
    [Tooltip("For turrent base lock to target and turn towards the target")]
    [SerializeField] private Transform turrentBase;
    [Tooltip("For turrent to point to target. For non-homing missile")]
    [SerializeField] private Transform turrentEndPoint;

    [Header("Target")]
    [SerializeField] private GameObject targetUnit;

    [Header("Tower State")]
    public TowerState towerState = TowerState.None;

    private void Start()
    {

    }

    public virtual void UpdateState()
    {
        switch (towerState)
        {
            //! Maybe best to set in the inspector for more dynamic behaviour
            case TowerState.None:

                break;

            //! This can be if user manually set this behavior
            case TowerState.Idle:

                break;

            case TowerState.SeekingEnemy:
                if (towerSensor == null || towerAttack == null)
                {
                    Debug.Log($"[BaseTower]: Component required to execute this behavior is null ");
                    return;
                }


                if (towerSensor.TargetList.Count > 0)
                {
                    targetUnit = towerSensor.TargetList[0];

                    towerState = TowerState.Attack;
                    UpdateState();
                }


                break;

            case TowerState.Attack:
                if (towerAttack == null)
                {
                    Debug.Log($"[BaseTower]: Component required to execute this behavior is null ");
                    return;
                }

                towerAttack.SetAttackTarget(targetUnit.GetComponent<BaseHealth>());

                break;

            case TowerState.Buff:

                break;

            //! Maybe after user execute something, it will do cooldown.
            //! TODO: Create a util for cooldown method
            case TowerState.CoolDown:

                break;
        }
    }

    public void OnTargetDetected()
    {

    }

    public void OnTargetLoss()
    {

    }

    public void SetTargetUnit(GameObject unit) => targetUnit = unit;

    public enum TowerState
    {
        None,
        Idle,
        SeekingEnemy,
        Attack,
        Buff, // For buff tower
        CoolDown
    }
}
