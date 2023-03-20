using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public static Dictionary<WeaponType, int> ammo = new()
    {
        [WeaponType.Flashlight] = 1,
        [WeaponType.Pistol] = 20,
        [WeaponType.SMG] = 20
    };
    [SerializeField] private WeaponType type;
    [SerializeField] private int amount;

    private void Start()
    {
        PublicObjects.UseController.OnHover += UseController_OnHover;
    }

    private void UseController_OnHover(Transform t)
    {
        if (Input.GetKeyDown(KeyCode.E) && t == transform)
        {
            PublicObjects.NoticeController.Notify(2, $"+{amount} патронов");
            ammo[type] += amount;

            PublicObjects.UseController.OnHover -= UseController_OnHover;
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        PublicObjects.UseController.OnHover -= UseController_OnHover;
    }
}