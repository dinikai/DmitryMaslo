using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PublicCollider : MonoBehaviour
{
    public bool inCollider;
    public string compareTag;
    public event EventHandler OnColliderEnter, OnColliderExit;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(compareTag))
        {
            inCollider = true;
            OnColliderEnter.Si(this, new EventArgs());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(compareTag))
        {
            inCollider = false;
            OnColliderExit.Si(this, new EventArgs());
        }
    }
}
