using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplayerManager : MonoBehaviourPunCallbacks
{
    public bool IsMultiplayer;
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private PlayerInfo singlePlayer;

    private void Awake()
    {
        singlePlayer.IsMultiplayer = IsMultiplayer;
    }

    void Start()
    {
        PhotonNetwork.Instantiate(playerPrefab.name, new Vector3(19, 3, 22), Quaternion.identity);
    }

    void Update()
    {
        
    }
}
