using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UPCPause : UIPanelController
{
    [Header("Button Reference")]
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button settingButton;
    [SerializeField] private Button endButton;

    public override void OnInitialized()
    {
        base.OnInitialized();

        resumeButton.onClick.AddListener(ResumeGame);
        settingButton.onClick.AddListener(OpenSettingsMenu);
        endButton.onClick.AddListener(EndGame);
    }

    private void ResumeGame()
    {
        UIManager.Instance.SetUIState(UIState.GameHud);
    }

    private void OpenSettingsMenu()
    {
        UIManager.Instance.SetUIState(UIState.Settings);
    }

    private void EndGame()
    {
        UIManager.Instance.SetUIState(UIState.MainMenu);
    }
}
