using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    
    
    public InputAction CameraAction;
    public InputAction CameraZoom;
    float inputValue;
    float zoomValue;
    float maxMagnitude = 400f;
    float minMagnitude = 150f;

    public Camera mainCam;
    void Start()
    {
        CameraAction.Enable();
        CameraZoom.Enable();
        print($"start mag is {mainCam.transform.position.magnitude}");
    }

    void Update()
    {
        zoomValue = CameraZoom.ReadValue<float>();
        inputValue = CameraAction.ReadValue<float>();

        if (zoomValue != 0)
        {
            print("PLUH9");
            ZoomCamera();
        }
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

    public void ZoomCamera()
    {
        if (zoomValue > 0 && mainCam.transform.position.magnitude >= minMagnitude)
        {
            print("iscalled");
            mainCam.transform.Translate(Vector3.forward * (zoomValue * 10));    
        } else if (zoomValue < 0 && mainCam.transform.position.magnitude <= maxMagnitude)
        {
            mainCam.transform.Translate(Vector3.forward * (zoomValue * 10));
            print("iscalled");
        }
        
    }

    void FixedUpdate()
    {
        RotateCamera();
    }
}
