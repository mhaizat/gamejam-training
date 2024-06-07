using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerHub : MonoBehaviour
{
    public static ManagerHub Instance { get; set; }

    [SerializeField] private PlayerControlsManager playerControlsManager;
    [SerializeField] private UnitManager unitManager;

    public PlayerControlsManager GetPlayerControlsManager() { return playerControlsManager; }
    public UnitManager GetUnitManager() { return unitManager; }

    void Awake()
    {
        if (Instance != null && Instance != this)
        { 
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }
}
