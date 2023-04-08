using System;
using UnityEngine;

public class PublicCollider : MonoBehaviour
{
    public bool InCollider;
    public event EventHandler OnColliderEnter, OnColliderExit;
    public bool OverrideTag;
    public string OverridedTag;
    string overridedTag = "";

    private void Start()
    {
        overridedTag = OverrideTag ? OverridedTag : "Player";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(overridedTag))
        {
            InCollider = true;
            OnColliderEnter.Si(this, new EventArgs());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(overridedTag))
        {
            InCollider = false;
            OnColliderExit.Si(this, new EventArgs());
        }
    }
}
