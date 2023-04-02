using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : ShootingWeapon
{
    private Animator animator;  

    private void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        RaycastHit hit = CheckAim();

        if (Input.GetMouseButtonDown(0) && !weaponSwitch.menuOpened && !cooldown)
        {
            animator.SetTrigger("Shoot");
            audioSource.clip = fireClip;
            audioSource.Play();

            if (enemyAim)
                Shoot(hit);
            cooldown = true;
            StartCoroutine(CooldownCoroutine());
        }
    }

    private IEnumerator CooldownCoroutine()
    {
        yield return new WaitForSeconds(cooldownTime);
        cooldown = false;
    }
}
