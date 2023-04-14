using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FnafFan : MonoBehaviour
{
    [SerializeField] Generator generator;

    private void Start()
    {
        generator.OnDown += (sender, e) =>
        {
            GetComponent<Animator>().enabled = false;
        };
    }
}
