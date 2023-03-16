using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Butter : MonoBehaviour
{
    private UseController useController;
    private NoticeController noticeController;
    private TextController textController;
    private TextMeshProUGUI butterCount;
    private bool hasCount;
    public static int buttersCount;
    [SerializeField] private AudioSource collectAudio;

    private void Awake()
    {
        useController = GameObject.FindGameObjectWithTag("UseController").GetComponent<UseController>();
        noticeController = GameObject.FindGameObjectWithTag("NoticeController").GetComponent<NoticeController>();
        textController = GameObject.FindGameObjectWithTag("Text").GetComponent<TextController>();
        if (GameObject.FindGameObjectWithTag("ButterCount"))
        {
            hasCount = true;
            butterCount = GameObject.FindGameObjectWithTag("ButterCount").GetComponent<TextMeshProUGUI>();
        } else
        {
            hasCount = false;
        }
        useController.OnHover += UseController_OnHover;
    }

    private void UseController_OnHover(Transform t)
    {
        if (Input.GetKeyDown(KeyCode.E) && t == transform)
        {
            buttersCount++;
            collectAudio.Play();
            useController.OnHover -= UseController_OnHover;
            noticeController.Notify(NoticeSprite.Butter, "+1 масло");
            if (hasCount) butterCount.text = $"{buttersCount}";
            if (buttersCount == 1)
            {
                textController.WriteText("Собирайте масло для создания оружия");
            }

            Destroy(gameObject);
        }
    }
}
