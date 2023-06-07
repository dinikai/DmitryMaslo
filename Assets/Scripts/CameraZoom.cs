using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    [SerializeField] private KeyCode key;
    public float ZoomFOV, ZoomIncremence;
    private float defaultFOV;
    private Camera mainCamera;

    private void Start()
    {
        defaultFOV = Camera.main.fieldOfView;
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetKey(key))
        {
            mainCamera.fieldOfView -= ZoomIncremence;
            if (mainCamera.fieldOfView < ZoomFOV)
                mainCamera.fieldOfView = ZoomFOV;
        } else
        {
            mainCamera.fieldOfView += ZoomIncremence;
            if (mainCamera.fieldOfView > defaultFOV)
                mainCamera.fieldOfView = defaultFOV;
        }
    }
}
