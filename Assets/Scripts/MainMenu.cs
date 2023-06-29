using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject settingsMenu, multiplayerMenu;

    public void Play() => SceneManager.LoadScene("History");

    public void Quit() => Application.Quit();

    public void OpenSettingsMenu() => settingsMenu.SetActive(true);

    public void OpenMultiplayerMenu() => multiplayerMenu.SetActive(true);
}
