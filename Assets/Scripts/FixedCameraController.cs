using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FixedCameraController : MonoBehaviour
{
    public FixedCamera[] cameras;
    public KeyCode[] keys;
    [SerializeField] private Transform player, playerCamera;
    [SerializeField] private GameObject cameraBodyPrefab;
    [SerializeField] private Canvas canvas, cameraCanvas;
    [SerializeField] private TextMeshProUGUI cameraNameText;

    public void ActivateCamera(int index)
    {
        if (!cameras[index].installed) return;
        foreach (var fixedCamera in cameras)
        {
            fixedCamera.GetComponent<Camera>().enabled = false;
        }
        cameras[index].GetComponent<Camera>().enabled = true;
        canvas.enabled = false;
        cameraCanvas.enabled = true;
        cameraNameText.text = $"Cam {index + 1}";
    }

    public void InstallCamera(int index)
    {
        cameras[index].installed = true;
        cameras[index].transform.position = player.position;
        cameras[index].transform.rotation = player.rotation;
        cameras[index].cameraBody = Instantiate(cameraBodyPrefab, player.position, player.rotation);
        cameras[index].cameraBody.GetComponent<FixedCameraBody>().text1.text = (index + 1).ToString();
        cameras[index].cameraBody.GetComponent<FixedCameraBody>().text2.text = (index + 1).ToString();
    }

    public void DeactivateCameras()
    {
        foreach (var fixedCamera in cameras)
        {
            fixedCamera.GetComponent<Camera>().enabled = false;
        }
        canvas.enabled = true;
        cameraCanvas.enabled = false;
    }

    public void UninstallCameras()
    {
        DeactivateCameras();
        foreach (var fixedCamera in cameras)
        {
            fixedCamera.installed = false;
            Destroy(fixedCamera.cameraBody);
        }
    }

    private void Update()
    {
        int index = -1;
        for (int i = 0; i < keys.Length; i++)
        {
            if (Input.GetKeyDown(keys[i]))
                index = i;
        }
        if (index != -1)
        {
            if (Input.GetKey(KeyCode.LeftShift))
                InstallCamera(index);
            else
                ActivateCamera(index);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
            DeactivateCameras();
    }
}