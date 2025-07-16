using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    
    
    public InputAction CameraAction;
    float inputValue;

    void Start()
    {
        CameraAction.Enable();
    }

    void Update()
    {
        RotateCamera();
        inputValue = CameraAction.ReadValue<float>();
    }

    public void RotateCamera()
    {
        if (inputValue > 0)
        {
            transform.Rotate(Vector3.up, -0.5f);
        }

        if (inputValue < 0)
        {
            transform.Rotate(Vector3.up, 0.5f);
        }
    }
    
    
}
