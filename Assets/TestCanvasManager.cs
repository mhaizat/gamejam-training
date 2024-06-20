using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TestCanvasManager : MonoBehaviour
{
    public static TestCanvasManager Instance;

    [SerializeField] private Button testTowerButton;
    [SerializeField] private Button testTowerButtonTwo;

    public bool canPlaceTower;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;
    }

    void Start()
    {
        testTowerButton.onClick.AddListener(PlaceTowerOne);
        testTowerButtonTwo.onClick.AddListener(PlaceTowerTwo);

    }

    //! NOTE(Haizat): Need to find a better name for towers
    void PlaceTowerOne()
    {
        UnitPoolManager.Instance.currentTag = "Tower 1";
        canPlaceTower = true;
    }

    //! NOTE(Haizat): Need to find a better name for towers
    void PlaceTowerTwo()
    {
        UnitPoolManager.Instance.currentTag = "Tower 2";
        canPlaceTower = true;
    }
}
