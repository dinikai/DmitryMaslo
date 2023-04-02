using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Butter : MonoBehaviour
{
    private TextMeshProUGUI butterCount;
    private bool hasCount;
    public static int buttersCount;
    [SerializeField] private AudioSource collectAudio;

    private void Start()
    {
        if (GameObject.FindGameObjectWithTag("ButterCount"))
        {
            hasCount = true;
            butterCount = GameObject.FindGameObjectWithTag("ButterCount").GetComponent<TextMeshProUGUI>();
        } else
        {
            hasCount = false;
        }
        PublicObjects.UseController.OnHover += UseController_OnHover;
    }

    private void UseController_OnHover(Transform t)
    {
        if (Input.GetKeyDown(KeyCode.E) && t == transform)
        {
            buttersCount++;
            collectAudio.Play();
            PublicObjects.NoticeController.Notify(0, "+1 масло");
            if (hasCount) butterCount.text = $"{buttersCount}";
            if (buttersCount == 1)
            {
                PublicObjects.TextController.WriteText("Собирайте масло для создания оружия");
            }

            PublicObjects.UseController.OnHover -= UseController_OnHover;
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        PublicObjects.UseController.OnHover -= UseController_OnHover;
    }
}
