using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    private TextController textController;
    public static int keysCount = 11;
    public int stage;
    public List<Vector3> stagePositions;
    public List<int> needKeys;
    [SerializeField] private float liftSpeed;
    [SerializeField] private Animator doorAnimator;
    [SerializeField] private Transform liftBody;
    [SerializeField] private List<GameObject> stagesObjects;
    public bool doorOpened, lift;
    [SerializeField] private TextMeshPro keysCountText;
    [SerializeField] private AudioSource openAudio, closeAudio;
    [SerializeField] private PublicCollider doorCollider, insideCollider;

    private void Awake()
    {
        textController = GameObject.FindGameObjectWithTag("Text").GetComponent<TextController>();
        doorCollider.OnColliderEnter += DoorCollider_OnColliderEnter;
        doorCollider.OnColliderExit += DoorCollider_OnColliderExit;
    }

    public void DoorCollider_OnColliderEnter(object sender, EventArgs e)
    {
        if (keysCount >= needKeys[stage])
        {
            doorOpened = true;
            doorAnimator.SetBool("Open", doorOpened);
            openAudio.Play();
        }
    }

    public void DoorCollider_OnColliderExit(object sender, EventArgs e)
    {
        doorOpened = false;
        doorAnimator.SetBool("Open", doorOpened);
        closeAudio.Play();
    }

    private void Update()
    {
        keysCountText.text = $"{keysCount}/{needKeys[stage]}";

        if (lift)
        {
            liftBody.position = Vector3.MoveTowards(liftBody.position, stagePositions[stage], liftSpeed);
            if (liftBody.position == stagePositions[stage])
            {
                lift = false;
                DoorCollider_OnColliderEnter(this, new EventArgs());
            }
        }
    }

    public void DoorOpened()
    {
        if (!doorOpened && insideCollider.inCollider)
        {
            stage++;
            lift = true;
            stagesObjects[stage - 1].gameObject.SetActive(false);
            stagesObjects[stage].gameObject.SetActive(true);
        }
    }
}
