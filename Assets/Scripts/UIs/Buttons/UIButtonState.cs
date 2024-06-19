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


    private void Start()
    {
        activeLine = GetComponentInChildren<Image>();
        buttonState = GetComponent<Button>();

        if(buttonState != null )
            buttonState.onClick.AddListener(SetButtonState);

        if (activeLine != null)
            activeLine.enabled = IsSelected;
    }

    public void SetButtonState()
    {
        if(buttonState != null)
        {
            IsSelected = !IsSelected;

            onPress?.Invoke(IsSelected);
        }

        if(activeLine != null)
        {
            activeLine.enabled = IsSelected;
        }
        else
        {
            Debug.Log($"[UI]: A component is missing. Unable to execute logic");
        }
    }
}
