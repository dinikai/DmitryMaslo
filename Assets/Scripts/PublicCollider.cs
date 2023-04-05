using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PublicCollider : MonoBehaviour
{
    public bool inCollider;
    public event EventHandler OnColliderEnter, OnColliderExit;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inCollider = true;
            OnColliderEnter.Si(this, new EventArgs());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inCollider = false;
            OnColliderExit.Si(this, new EventArgs());
        }
    }
}
