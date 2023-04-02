using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator animator;
    private AudioSource doorAudio;
    private BoxCollider boxCollider;
    public bool opened = false, locked = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
        doorAudio = GetComponent<AudioSource>();
        PublicObjects.UseController.OnHover += UseController_OnHover;
        boxCollider = GetComponent<BoxCollider>();
    }

    private void UseController_OnHover(Transform t)
    {
        if (Input.GetKeyDown(KeyCode.E) && t == transform)
        {
            if (!locked)
            {
                SetDoorState(!opened);
            } else
            {
                doorAudio.clip = PublicObjects.doorLocked;
                doorAudio.Play();
            }
        }
    }

    public void SetDoorState(bool state)
    {
        opened = state;
        doorAudio.clip = PublicObjects.doorOpen;
        doorAudio.Play();
        boxCollider.isTrigger = true;
        animator.SetBool("Open", state);
    }

    private void OnDestroy()
    {
        PublicObjects.UseController.OnHover -= UseController_OnHover;
    }

    public void Animator_OnAnimationEnd()
    {
        boxCollider.isTrigger = false;
    }
}