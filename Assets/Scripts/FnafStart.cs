using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FnafStart : MonoBehaviour
{
    [SerializeField] private GameObject zombie;
    [SerializeField] private Generator generator;

    private void Start()
    {
        GetComponent<PublicCollider>().OnColliderEnter += PlayCollider_OnColliderEnter;
    }

    private void PlayCollider_OnColliderEnter(object sender, EventArgs e)
    {
        zombie.SetActive(true);
        generator.StartCoroutine(generator.DischargeCoroutine());
        Destroy(gameObject);
    }
}
