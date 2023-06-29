using System;
using UnityEngine;

public class PublicCollider : MonoBehaviour
{
    public bool InCollider;
    public virtual event EventHandler OnColliderEnter, OnColliderExit;
    public bool OverrideTag;
    public string OverridedTag;
    protected string overridedTag = "";

    private void Start()
    {
        overridedTag = OverrideTag ? OverridedTag : "Player";
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(overridedTag))
        {
            InCollider = true;
            OnColliderEnter?.Invoke(this, new EventArgs());
        }
    }

    protected virtual void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(overridedTag))
        {
            InCollider = false;
            OnColliderExit?.Invoke(this, new EventArgs());
        }
    }
}
