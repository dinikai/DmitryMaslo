using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Door : MonoBehaviour
{
    private UseController useController;
    private Animator animator;
    private AudioSource doorAudio;
    public bool opened = false;

    private void Awake()
    {
        useController = GameObject.FindGameObjectWithTag("UseController").GetComponent<UseController>();
        animator = GetComponent<Animator>();
        doorAudio = GetComponent<AudioSource>();
        useController.OnHover += UseController_OnHover;
    }

    private void UseController_OnHover(Transform t)
    {
        if (Input.GetKeyDown(KeyCode.E) && t == transform)
        {
            opened = !opened;
            doorAudio.Play();
            animator.SetBool("Open", opened);
        }
    }
}