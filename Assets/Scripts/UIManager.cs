using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private UIPanelController _mainMenuPanel;
    [SerializeField] private UIPanelController _settingPanel;

    private void Start()
    {
        ManagerHub.Instance.SetUIManager(this);

        OnInitialized();
    }

    public void OnInitialized()
    {
        _mainMenuPanel.SetPanelActive(true);

        _settingPanel.SetPanelActive(false);
    }
}
