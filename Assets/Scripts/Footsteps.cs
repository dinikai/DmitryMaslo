using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    [SerializeField] private AudioSource footsteps;

    public void StepSound()
    {
        footsteps.pitch = Random.Range(0.9f, 1f);
        footsteps.Play();
    }
}
