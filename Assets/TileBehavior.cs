using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBehavior : MonoBehaviour
{
    [SerializeField] private bool isTileInteractable;

    [SerializeField] private bool isObjectPlaced;
    [SerializeField] private bool isTileAPath;

    public bool GetIsTileInteractable() { return isTileInteractable; }
    public bool GetIsObjectPlaced() { return isObjectPlaced; }
    public bool GetIsTileAPath() { return isTileAPath; }

    public void SetIsTileInteractable(bool isInteractable) { isTileInteractable = isInteractable; }
    public void SetIsObjectPlaced(bool isPlaced) { isObjectPlaced = isPlaced; }
    public void SetIsTileAPath(bool isPath) { isTileAPath = isPath; }
}
