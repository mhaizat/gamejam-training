using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private ManagerHub managerHub;


    //! putting this here for now
    public LayerMask interactableLayerMask;
    
    void Start()
    {
        managerHub = ManagerHub.Instance;
    }

    void FixedUpdate()
    {
        if (managerHub.GetInputManager().GetMouseLeftClick() == 1.0f)
        {
            HandleTileInput();
        }
    }

    void HandleTileInput()
    {
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, interactableLayerMask))
        {
            if (hit.collider != null)
            {
                Debug.Log(hit.collider.gameObject.name);

                TileBehavior tileBehavior = hit.collider.gameObject.GetComponent<TileBehavior>();

                if (tileBehavior)
                {
                    if (tileBehavior.GetIsTileInteractable() && TestCanvasManager.Instance.canPlaceTower)
                    {
                        TestCanvasManager.Instance.canPlaceTower = false;
                        tileBehavior.SetIsTileInteractable(false);

                        UnitPoolManager.Instance.SpawnFromPool(UnitPoolManager.Instance.currentTag, tileBehavior.gameObject.transform.position, tileBehavior.gameObject.transform.rotation);
                        Debug.Log("Works");
                    }
                }
            }
        }
    }
}
