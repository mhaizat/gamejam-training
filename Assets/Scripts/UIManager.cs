using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    /// <summary>
    /// Remove this after debugging
    /// </summary>
    private static UIManager instance;
    public static UIManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<UIManager>();
            }

            return instance;
        }
    }

    private void Start()
    {
        if(ManagerHub.Instance != null)
            ManagerHub.Instance.SetUIManager(this);

        OnInitialized();
    }

    public void OnInitialized()
    {
        mainMenuPanel.OnInitialized();
        settingPanel.OnInitialized();
        gamePanel.OnInitialized();
        popupPanel.OnInitialized();
        pausePanel.OnInitialized();

        SetUIState(UIState.MainMenu);
    }

    public void SetUIState(UIState state)
    {
        DeactivatePanels();

        switch (state)
        {
            case UIState.MainMenu:
                mainMenuPanel.SetPanelActive(true);
            break;

            case UIState.Settings:
                settingPanel.SetPanelActive(true);
            break;

            case UIState.GameHud:
                gamePanel.SetPanelActive(true);
            break;

            case UIState.PopUp:
                popupPanel.SetPanelActive(true);
            break;

            case UIState.Pause:
                pausePanel.SetPanelActive(true);
            break;
        }
    }

    private void DeactivatePanels()
    {
        mainMenuPanel.SetPanelActive(false);
        settingPanel.SetPanelActive(false);
        gamePanel.SetPanelActive(false);
        popupPanel.SetPanelActive(false);
        pausePanel.SetPanelActive(false);
    }
}

public enum UIState
{
    None,
    MainMenu,
    Settings,
    GameHud,
    PopUp,
    Pause
}