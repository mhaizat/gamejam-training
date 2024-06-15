using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTower : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private StatsSO towerStat;
    [SerializeField] private BaseSensor towerSensor;
    [SerializeField] private BaseHealth towerHealth;

    [Header("Visual")]
    [Tooltip("For turrent base lock to target and turn towards the target")]
    [SerializeField] private Transform turrentBase;
    [Tooltip("For turrent to point to target. For non-homing missile")]
    [SerializeField] private Transform turrentEndPoint;

    [Header("Target")]
    [SerializeField] private GameObject targetUnit;


    private void Start()
    {

    }

    public virtual void UpdateState()
    {

    }

    public void SetTargetUnit(GameObject unit) => targetUnit = unit;
}
