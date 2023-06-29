using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MenuWindow
{
    public FullScreenMode FullScreenMode;
    [SerializeField] private TMP_Dropdown resolutionDropdown;
    [SerializeField] private Toggle fullscreenToggle;

    private void Start()
    {
        resolutionDropdown.onValueChanged.AddListener((i) =>
        {
            int w = Convert.ToInt32(resolutionDropdown.options[i].text.Split('x')[0]);
            int h = Convert.ToInt32(resolutionDropdown.options[i].text.Split('x')[1]);
            Screen.SetResolution(w, h, Screen.fullScreenMode);
        });
        fullscreenToggle.onValueChanged.AddListener((value) =>
        {
            Screen.fullScreenMode = value ? FullScreenMode.FullScreenWindow : FullScreenMode.Windowed;
        });
    }
}
