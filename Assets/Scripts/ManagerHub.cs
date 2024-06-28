using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerHub : MonoBehaviour
{
    public static ManagerHub Instance { get; set; }

    [SerializeField] private InputManager inputManager;
    [SerializeField] private EnemyPoolManager enemyPoolManager;
    [SerializeField] private UIManager uiManager;
    [SerializeField] private GridManager gridManager;
    [SerializeField] private WaveManager waveManager;


    public WaveManager GetWaveManager() { return waveManager; }
    public InputManager GetInputManager() { return inputManager; }
    public EnemyPoolManager GetEnemyPoolManager() { return enemyPoolManager; }

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
