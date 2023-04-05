using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public bool collidedWithPlayer = false;
    private PlayerInfo playerInfo;

    private void Start()
    {
        playerInfo = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>();
        StartCoroutine(AttackCoroutine());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //playerInfo.SetHp(playerInfo.Hp - .05f);
            collidedWithPlayer = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collidedWithPlayer = false;
        }
    }

    private IEnumerator AttackCoroutine()
    {
        while (true)
        {
            if (collidedWithPlayer)
            {
                //playerInfo.SetHp(playerInfo.Hp - .05f);
            }
            yield return new WaitForSeconds(.6f);
        }
    }
}
