using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    public float Hp = 1;
    [SerializeField] private Image healthBar;
    [SerializeField] private AudioSource hitAudio;

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
