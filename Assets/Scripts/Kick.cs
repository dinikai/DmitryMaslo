using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kick : MonoBehaviour
{
    [SerializeField] private Animator handAnimator;
    [SerializeField] private AudioSource kickAudio;
    [SerializeField] private CraftController craftController;
    [SerializeField] private float kickDistance, kickDamage, kickCooldown;
    [SerializeField] private WeaponSwitch weaponSwitch;
    [SerializeField] private WeaponParent weaponParent;
    public bool canCraft, canKick;
    public bool kickCooldownEnd = true, enemyAim;

    private void Update()
    {
        canKick = true;
        if (canCraft)
            canKick = !craftController.bodyShown;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        enemyAim = false;

        if (Physics.Raycast(ray, out hit, kickDistance))
        {
            if (hit.transform.CompareTag("Zombie"))
            {
                enemyAim = true;
            }
        }

        if (Input.GetMouseButtonDown(0) && canKick && kickCooldownEnd && !weaponSwitch.menuOpened && weaponParent.selectedWeapon == 0)
        {
            handAnimator.SetTrigger("Kick");
            kickAudio.Play();
            if (enemyAim)
            {
                EnemyAI enemyAI = hit.transform.GetComponent<EnemyAI>();
                enemyAI.SetHp(enemyAI.hp - kickDamage);
            }
            kickCooldownEnd = false;
            StartCoroutine(CooldownCoroutine());
        }
    }

    private IEnumerator CooldownCoroutine()
    {
        yield return new WaitForSeconds(kickCooldown);
        kickCooldownEnd = true;
    }
}
