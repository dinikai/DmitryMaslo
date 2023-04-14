using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCTVController : MonoBehaviour
{
    public GameObject[] Cameras, Screens;
    [SerializeField] AudioSource audioSource, errorAudio;
    [SerializeField] Material idle, pressed;
    [SerializeField] MeshRenderer[] buttons;
    [SerializeField] Generator generator;

    private void Start()
    {
        generator.OnDown += (sender, e) => DisableCameras();
    }

    public void UseCamera(int index)
    {
        if (!generator.IsWorking)
        {
            errorAudio.Play();
            return;
        }
        for (int i = 0; i < Cameras.Length; i++)
        {
            Cameras[i].SetActive(false);
            Screens[i].SetActive(false);
            buttons[i].sharedMaterial = idle;
        }

        Cameras[index].SetActive(true);
        Screens[index].SetActive(true);
        buttons[index].sharedMaterial = pressed;
        audioSource.Play();
    }

    public void DisableCameras()
    {
        for (int i = 0; i < Cameras.Length; i++)
        {
            Cameras[i].SetActive(false);
            Screens[i].SetActive(false);
            buttons[i].sharedMaterial = idle;
        }
    }
}
