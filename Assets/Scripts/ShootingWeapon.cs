using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShootingWeapon : MonoBehaviour
{
    public int Ammo { get; set; }
    [SerializeField] protected WeaponSwitch weaponSwitch;
    [SerializeField] private WeaponParent weaponParent;
    protected AudioSource audioSource;
    [SerializeField] protected AudioClip fireClip, reloadClip, emptyClip;
    public bool cooldown, enemyAim;
    public float cooldownTime, maxDistance, damage;

    public RaycastHit CheckAim()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        enemyAim = false;

        if (Physics.Raycast(ray, out hit, maxDistance))
        {
            if (hit.transform.CompareTag("Zombie"))
            {
                enemyAim = true;
            }
        }

        return hit;
    }

    public void Shoot(RaycastHit hit)
    {
        EnemyAI enemyAI = hit.transform.GetComponent<EnemyAI>();
        enemyAI.SetHp(enemyAI.hp - damage);
    }
}