using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    PlayerControls playerControls;

    private void Awake()
    {
        playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    public float GetMouseLeftClick()
    {
        return playerControls.Movement.LeftMouseClick.ReadValue<float>();
    }

    public Vector2 GetCameraPan()
    { 
        return playerControls.CameraMovement.Pan.ReadValue<Vector2>();
    }

    //public void GetCameraZoom()
    //{ 
    //    return playerControls.CameraMovement.Zoom.ReadValue<float>();
    //}
}
