using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponParent : MonoBehaviour
{
    public int lastId, selectedWeapon = 0;
    public Transform[] ownedWeapon;

    public void Switch(int id)
    {
        lastId = id;
        GetComponent<Animator>().SetTrigger("Switch");
    }

    public void OnParentDown()
    {
        foreach (Transform transform in transform)
        {
            transform.gameObject.SetActive(false);
        }
        transform.GetChild(lastId).gameObject.SetActive(true);
    }
}
