using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCTVController : MonoBehaviour
{
    public GameObject[] Cameras, Screens;
    [SerializeField] AudioSource audioSource;
    [SerializeField] Material idle, pressed;
    [SerializeField] MeshRenderer[] buttons;

    public void UseCamera(int index)
    {
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
}
