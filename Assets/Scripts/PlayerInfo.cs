using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    public float Hp = 1;
    [SerializeField] private Image healthBar;
    [SerializeField] private AudioSource hitAudio;
    public bool IsMultiplayer;
    [SerializeField] private UseController useController;
    [SerializeField] private NoticeController noticeController;
    [SerializeField] private TextController textController;
    private PhotonView photonView;

    private void Awake()
    {
        if (IsMultiplayer)
        {
            if (photonView.IsMine)
            {
                PublicObjects.UseController = useController;
                PublicObjects.NoticeController = noticeController;
                PublicObjects.TextController = textController;
            }
        }
    }

    private void Start()
    {
        photonView = GetComponent<PhotonView>();
    }

    public void SetHp(float hp)
    {
        if (hp < Hp)
        {
            hitAudio.Play();
        }
        Hp = hp;
        healthBar.fillAmount = Hp;
    }
}
