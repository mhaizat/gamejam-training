using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BaseSensor : MonoBehaviour
{
    [SerializeField] private LayerMask targetLayer;

    [Header("Target Found")]
    [SerializeField] private List<GameObject> targetList;

    [Header("Event")]
    public UnityEvent OnTargetDetected;

    public UnityEvent OnTargetLoss;

    private void OnTriggerEnter(Collider collider)
    {
        if (targetLayer == (targetLayer | 1 << collider.gameObject.layer))
        {
            targetList.Add(collider.gameObject);
            OnTargetDetected?.Invoke();
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (targetLayer == (targetLayer | 1 << collider.gameObject.layer))
        {
            targetList.Remove(collider.gameObject);
            OnTargetLoss?.Invoke();
        }
    }

    public List<GameObject> TargetList => targetList;
}
