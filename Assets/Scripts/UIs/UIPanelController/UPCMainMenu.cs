using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UPCMainMenu : UIPanelController
{
    [Header("Buttons")]
    [SerializeField] private Button startButton;
    [SerializeField] private Button settingButton;
    [SerializeField] private Button quitButton;

    public override void OnInitialized()
    {
        base.OnInitialized();

        startButton.onClick.AddListener(StartGame);
        settingButton.onClick.AddListener(OpenSettingMenu);
        quitButton.onClick.AddListener(QuitGame);
    }

    private void StartGame()
    {
        UIManager.Instance.SetUIState(UIState.GameHud);
    }

    private void OpenSettingMenu()
    {
        UIManager.Instance.SetUIState(UIState.Settings);
    }

    private void QuitGame()
    {
        if(Application.isPlaying)
        {
            Application.Quit();
        }
    }
}
