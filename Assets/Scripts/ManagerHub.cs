using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerHub : MonoBehaviour
{
    public static ManagerHub Instance { get; set; }

    [SerializeField] private PlayerControlsManager playerControlsManager;
    [SerializeField] private UnitManager unitManager;
    [SerializeField] private UIManager uiManager;
    [SerializeField] private GridManager gridManager;
    public PlayerControlsManager GetPlayerControlsManager() { return playerControlsManager; }
    public UnitManager GetUnitManager() { return unitManager; }

    public UIManager GetUIManager() {  return uiManager; }
    public GridManager GetGridManager() { return gridManager; }

    void Awake()
    {
        if (Instance != null && Instance != this)
        { 
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        GameInstance.Instance.LoadUIScene();
    }

    public void SetUIManager(UIManager manager)=> uiManager = manager;
}
