using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuWindow : MonoBehaviourPunCallbacks
{
    public void OnCloseButtonClick()
    {
        gameObject.SetActive(false);
    }
}
