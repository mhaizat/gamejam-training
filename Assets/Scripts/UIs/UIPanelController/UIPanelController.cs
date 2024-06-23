using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPanelController : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;

    private void Awake()
    {
        if (_canvasGroup == null)
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }
    }

    public void SetPanelActive(bool isActive)
    {
        _canvasGroup.alpha = isActive ? 1.0f : 0f;        
        _canvasGroup.blocksRaycasts = isActive;
        _canvasGroup.interactable = isActive;
    }

    public virtual void OnInitialized() { }
}
