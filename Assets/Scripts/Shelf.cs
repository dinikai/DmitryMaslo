using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shelf : MonoBehaviour
{
    [SerializeField] private Animator doorL, doorR, zombieAnimator;
    [SerializeField] private EnemyAI zombieAI;
    public bool zombieShelf;
    private AudioSource doorAudio;
    public bool opened = false, openedOnce = false;

    private void Start()
    {
        doorAudio = GetComponent<AudioSource>();
    }

    public void ChangeDoorState()
    {
        opened = !opened;
        doorAudio.Play();
        doorL.SetBool("OpenL", opened);
        doorR.SetBool("OpenR", opened);
        if (!openedOnce && zombieShelf)
        {
            zombieAI.hasDestination = true;
            zombieAnimator.SetTrigger("Run");
        }
        openedOnce = true;
    }
}
