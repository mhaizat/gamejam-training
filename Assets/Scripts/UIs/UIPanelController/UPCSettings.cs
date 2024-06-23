using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class UPCSettings : UIPanelController
{
    [Header("Button Reference")]
    [SerializeField] private Button displayButton;
    [SerializeField] private Button graphicButton;
    [SerializeField] private Button audioButton;

    [SerializeField] private Button saveButton;
    [SerializeField] private Button cancelButton;

    [Header("Panel Reference")]
    [SerializeField] private UIPanelController displayPanelController;
    [SerializeField] private UIPanelController graphicPanelController;
    [SerializeField] private UIPanelController audioPanelController;

    [Header("UI Previous State Reference")]
    public UIState previousUIState = UIState.None;
     
    public override void OnInitialized()
    {
        base.OnInitialized();

        displayButton.onClick.AddListener(OpenDisplayMenu);
        graphicButton.onClick.AddListener(OpenGraphicMenu);
        audioButton.onClick.AddListener(OpenAudioMenu);

        cancelButton.onClick.AddListener(CancelSettingMenu);
    }

    private void OpenDisplayMenu()
    {
        DeactivatePanel();

        displayPanelController.SetPanelActive(true);
    }

    private void OpenGraphicMenu()
    {
        DeactivatePanel();

        graphicPanelController.SetPanelActive(true);
    }

    private void OpenAudioMenu()
    {
        DeactivatePanel();

        audioPanelController.SetPanelActive(true);
    }

    private void DeactivatePanel()
    {
        displayPanelController.SetPanelActive(false);
        graphicPanelController.SetPanelActive(false);
        audioPanelController.SetPanelActive(false);
    }

    private void CancelSettingMenu()
    {
        UIManager.Instance.SetUIState(previousUIState);
        // ManagerHub.Instance.GetUIManager().SetUIState(previousUIState);
    }
}
