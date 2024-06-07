using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    [SerializeField] private List<Unit> unitList = new List<Unit>();

    [SerializeField] private List<Unit> unitSelectedList = new List<Unit>();

    //! set up the current selected unit or group of units?
    //! 

    private void Awake()
    {
    }

    public void AddUnitToList(Unit unit)
    {
        unitList.Add(unit);
        unitSelectedList.Add(unit);
    }

    public void RemoveUnitFromList(Unit unit)
    {
        unitList.Remove(unit);
        unitSelectedList.Remove(unit);
    }

    public List<Unit> GetUnitList() { return unitList; }
    public List<Unit> GetUnitSelectedList() { return unitSelectedList; }
}
