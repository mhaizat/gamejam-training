using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    [SerializeField] private float panSpeed;

    private Transform camTransform;

    private ManagerHub managerHub;

    void Start()
    {
        camTransform = this.transform;

        managerHub = ManagerHub.Instance;
    }

    void Update()
    {
        Vector2 cameraDirection = managerHub.GetInputManager().GetCameraPan();

        if (cameraDirection.x != 0 || cameraDirection.y != 0)
        { 
            CameraPan(cameraDirection.x , cameraDirection.y);
        }
    }

    private Vector2 PanDirection(float x, float z)
    { 
        Vector2 direction = Vector2.zero;

        if (z >= Screen.height * 0.95f)
        {
            direction.y += 1;
        }
        else if (z <= Screen.height * 0.05f)
        {
            direction.y -= 1;
        }

        if (x >= Screen.width * 0.95f)
        {
            direction.x += 1;
        }
        else if (x <= Screen.width * 0.05f)
        {
            direction.x -= 1;
        }

        return direction;
    }

    private void CameraPan(float x, float z)
    {
        Vector2 direction = PanDirection(x, z);
        Vector3 moveDirection = new Vector3(direction.x, 0, direction.y);

        camTransform.position = Vector3.Lerp(camTransform.position, camTransform.position + moveDirection * panSpeed, Time.deltaTime);
    }
}
