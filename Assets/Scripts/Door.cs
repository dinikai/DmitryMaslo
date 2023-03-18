using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Door : MonoBehaviour
{
    private UseController useController;
    private Animator animator;
    private AudioSource doorAudio;
    private BoxCollider boxCollider;
    public bool opened = false;

    private void Awake()
    {
        useController = GameObject.FindGameObjectWithTag("UseController").GetComponent<UseController>();
        animator = GetComponent<Animator>();
        doorAudio = GetComponent<AudioSource>();
        useController.OnHover += UseController_OnHover;
        boxCollider = GetComponent<BoxCollider>();
    }

    private void UseController_OnHover(Transform t)
    {
        if (Input.GetKeyDown(KeyCode.E) && t == transform)
        {
            opened = !opened;
            doorAudio.Play();
            boxCollider.isTrigger = true;
            animator.SetBool("Open", opened);
        }
    }

    public void Animator_OnAnimationEnd()
    {
        boxCollider.isTrigger = false;
    }
}