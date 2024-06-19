using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UPCPopUp : UIPanelController
{
    [Header("Button Reference")]
    [SerializeField] private Button confirmButton;

    public override void OnInitialized()
    {
        base.OnInitialized();

        confirmButton.onClick.AddListener(ClosePanel);
    }

    private void ClosePanel()
    {
        SetPanelActive(false);
    }
}
