using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    [SerializeField] private List<EnemyBehavior> unitList = new List<EnemyBehavior>();

    [SerializeField] private List<EnemyBehavior> unitSelectedList = new List<EnemyBehavior>();

    public void AddUnitToList(EnemyBehavior enemyBehavior)
    {
        unitList.Add(enemyBehavior);
        unitSelectedList.Add(enemyBehavior);
    }

    public void RemoveUnitFromList(EnemyBehavior enemyBehavior)
    {
        unitList.Remove(enemyBehavior);
        unitSelectedList.Remove(enemyBehavior);
    }

    public List<EnemyBehavior> GetUnitList() { return unitList; }
    public List<EnemyBehavior> GetUnitSelectedList() { return unitSelectedList; }
}
