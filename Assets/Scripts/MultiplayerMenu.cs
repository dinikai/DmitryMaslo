using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MultiplayerMenu : MenuWindow
{
    [SerializeField] private TMP_InputField roomName, nickname;

    private void Start()
    {
        PhotonNetwork.NickName = Guid.NewGuid().ToString();
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.GameVersion = Application.version;
        PhotonNetwork.ConnectUsingSettings();
    }

    public void CreateRoom()
    {
        PhotonNetwork.NickName = nickname.text;
        if (PhotonNetwork.IsConnectedAndReady)
            PhotonNetwork.CreateRoom(roomName.text, new RoomOptions { MaxPlayers = 3 });
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game");
    }

    public void JoinRoom()
    {
        PhotonNetwork.NickName = nickname.text;
        if (PhotonNetwork.IsConnectedAndReady)
            PhotonNetwork.JoinRoom(roomName.text);
    }
}
