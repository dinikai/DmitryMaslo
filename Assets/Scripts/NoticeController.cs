using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NoticeController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI noticeText;
    [SerializeField] private Image noticeImage;
    private Animator animator;
    public List<Sprite> sprites = new List<Sprite>();

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Notify(NoticeSprite sprite, string notice)
    {
        animator.SetTrigger("Notify");
        noticeImage.sprite = sprites[(int)sprite];
        noticeText.text = notice;
    }
}

public enum NoticeSprite
{
    Butter,
    Key
}
