using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    private UseController useController;
    private NoticeController noticeController;
    public static Dictionary<WeaponType, int> ammo = new()
    {
        [WeaponType.Pistol] = 20,
        [WeaponType.SMG] = 20
    };
    [SerializeField] private WeaponType type;
    [SerializeField] private int amount;

    private void Awake()
    {
        useController = GameObject.FindGameObjectWithTag("UseController").GetComponent<UseController>();
        noticeController = GameObject.FindGameObjectWithTag("NoticeController").GetComponent<NoticeController>();
        useController.OnHover += UseController_OnHover;
    }

    private void UseController_OnHover(Transform t)
    {
        if (Input.GetKeyDown(KeyCode.E) && t == transform)
        {
            noticeController.Notify(2, $"+{amount} патронов");
            ammo[type] += amount;

            useController.OnHover -= UseController_OnHover;
            Destroy(gameObject);
        }
    }
}

public enum WeaponType
{
    Pistol,
    SMG
}