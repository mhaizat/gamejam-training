using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIButtonState : MonoBehaviour
{
    [SerializeField] private Image activeLine;
    [SerializeField] private bool IsSelected = false;

    private Button buttonState;

    [Space(20)]
    public UnityEvent<bool> onPress = null;

    [Space(20)]
    [SerializeField] private UIButtonStateGroup buttonStateGroup;


    private void Start()
    {
        activeLine = GetComponentInChildren<Image>();
        buttonState = GetComponent<Button>();

        if(buttonState != null )
            buttonState.onClick.AddListener(SetButtonState);

        if (activeLine != null)
            activeLine.enabled = IsSelected;

        if (buttonStateGroup != null)
        {
            buttonStateGroup.RegisterButton(this);
            buttonStateGroup.OnButtonOff += SetButtonOff;
        }
    }

    public void SetButtonState()
    {
        if(buttonStateGroup != null)
        {
            buttonStateGroup.NotifyButtonsOn(this);
        }

         if (buttonState != null)
        {
            IsSelected = true;

            onPress?.Invoke(IsSelected);
        }

        if (activeLine != null)
        {
            activeLine.enabled = IsSelected;
        }
        else
        {
            Debug.Log($"[UI]: A component is missing. Unable to execute logic");
        }
    }

    private void SetButtonOff() 
    {
        if(buttonState != null)
        {
            IsSelected = false;

            onPress?.Invoke(IsSelected);
        }

        if (activeLine != null)
        {
            activeLine.enabled = IsSelected;
        }
        else
        {
            Debug.Log($"[UI]: A component is missing. Unable to execute logic");
        }
    }

    private void OnDisable()
    {
        buttonStateGroup.OnButtonOff -= SetButtonOff;
    }
}
