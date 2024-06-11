using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIManager : MonoBehaviour
{
    #region variables
    [SerializeField] private InterfaceSO _interfaceSO;

    [Header("UI Panel Controller")]
    [SerializeField] private UIPanelController mainMenuPanel;
    [SerializeField] private UIPanelController settingPanel;
    [SerializeField] private UIPanelController gamePanel;
    [SerializeField] private UIPanelController popupPanel;
    [SerializeField] private UIPanelController pausePanel;
    #endregion


    private void Start()
    {
        ManagerHub.Instance.SetUIManager(this);

        OnInitialized();
    }

    public void OnInitialized()
    {
        mainMenuPanel.SetPanelActive(true);

        settingPanel.SetPanelActive(false);
        gamePanel.SetPanelActive(false);
        popupPanel.SetPanelActive(false);
        pausePanel.SetPanelActive(false);
    }
}
