using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FixedCameraController : MonoBehaviour
{
    public FixedCamera[] cameras;
    public KeyCode[] keys;
    [SerializeField] private Transform player, playerCamera, UIContainer;
    [SerializeField] private GameObject cameraBodyPrefab, UIPrefab;
    [SerializeField] private Canvas canvas, cameraCanvas;
    [SerializeField] private TextMeshProUGUI cameraNameText;
    [SerializeField] private AudioSource openAudio, staticAudio;

    private void Start()
    {
        /*for (int i = 0; i < cameras.Length; i++)
            Instantiate(UIPrefab, UIContainer);*/

        UninstallCameras();
    }

    public void ActivateCamera(int index)
    {
        if (!cameras[index].Installed) return;
        foreach (var fixedCamera in cameras)
        {
            fixedCamera.GetComponent<Camera>().enabled = false;
        }
        cameras[index].GetComponent<Camera>().enabled = true;
        canvas.enabled = false;
        cameraCanvas.enabled = true;
        cameraNameText.text = $"Cam {index + 1}";

        openAudio.Play();
        staticAudio.Play();
    }

    public void InstallCamera(int index)
    {
        cameras[index].Installed = true;
        cameras[index].transform.position = player.position;
        cameras[index].transform.rotation = player.rotation;
        cameras[index].CameraBody = Instantiate(cameraBodyPrefab, player.position, player.rotation);
        cameras[index].CameraBody.GetComponent<FixedCameraBody>().text1.text = (index + 1).ToString();
        cameras[index].CameraBody.GetComponent<FixedCameraBody>().text2.text = (index + 1).ToString();

        //UIContainer.GetChild(index).GetComponent<Image>().color = Color.white;
    }

    public void DeactivateCameras()
    {
        foreach (var fixedCamera in cameras)
        {
            fixedCamera.GetComponent<Camera>().enabled = false;
        }
        canvas.enabled = true;
        cameraCanvas.enabled = false;

        openAudio.Play();
        staticAudio.Stop();
    }

    public void UninstallCameras()
    {
        bool anyCamActive = false;
        foreach (var camera in cameras)
            if (camera.GetComponent<Camera>().enabled) anyCamActive = true;
        if (anyCamActive)
            DeactivateCameras();
        foreach (var fixedCamera in cameras)
        {
            fixedCamera.Installed = false;
            Destroy(fixedCamera.CameraBody);
        }
        /*foreach (Transform UI in UIContainer)
        {
            UI.GetComponent<Image>().color = new Color(1, 1, 1, .3f);
        }*/
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

        bool anyCamActive = false;
        foreach (var camera in cameras)
            if (camera.GetComponent<Camera>().enabled) anyCamActive = true;
        if (Input.GetKeyDown(KeyCode.Escape) && anyCamActive)
            DeactivateCameras();
    }
}