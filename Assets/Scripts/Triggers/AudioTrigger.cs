using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrigger : Trigger
{
    [SerializeField] private AudioSource audioSource;

    public override void RunTrigger()
    {
        audioSource.Play();
    }
}