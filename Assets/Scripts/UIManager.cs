using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private void Awake()
    {
        ManagerHub.Instance.SetUIManager(this);
    }
}
