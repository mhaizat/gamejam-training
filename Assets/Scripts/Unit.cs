using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    void Start()
    {
        AddUnitToList();
    }


    void AddUnitToList()
    {
        ManagerHub.Instance.GetUnitManager().AddUnitToList(this);
    }

    private void OnDestroy()
    {
        ManagerHub.Instance.GetUnitManager().RemoveUnitFromList(this);
    }
}
