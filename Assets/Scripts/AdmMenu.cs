using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdmMenu : MonoBehaviour
{
    [SerializeField] InputField widthText, heightText;

    public void Button_OnClick()
    {
        int w = Convert.ToInt32(widthText.text);
        int h = Convert.ToInt32(heightText.text);
        Screen.SetResolution(w, h, true);
    }
}
