using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonStateGroup : MonoBehaviour
{
    [SerializeField] private List<UIButtonState> uiButtonStatesList = new List<UIButtonState>();

    public Action OnButtonOff;

    //! Register all the buttons events
    public void RegisterButton(UIButtonState buttonState)
    {
        uiButtonStatesList.Add(buttonState);
    }

    public void NotifyButtonsOn(UIButtonState buttonState)
    {
        OnButtonOff?.Invoke();
    }    
}
