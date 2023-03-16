using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    private UseController useController;
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

    private void Awake()
    {
        useController = GameObject.FindGameObjectWithTag("UseController").GetComponent<UseController>();
        textController = GameObject.FindGameObjectWithTag("Text").GetComponent<TextController>();
        useController.OnHover += UseController_OnHover;
    }

    private void UseController_OnHover(Transform t)
    {
        if (Input.GetKeyDown(KeyCode.E) && t == transform)
        {
            if (keysCount >= needKeys[stage])
            {
                doorOpened = !doorOpened;
                doorAnimator.SetBool("Open", doorOpened);

                if (doorOpened)
                    openAudio.Play();
                else
                    closeAudio.Play();
            }
            else
            {
                textController.WriteText($"Нужно {needKeys[stage]} ключей");
            }
        }
    }

    private void Update()
    {
        keysCountText.text = $"{keysCount}/{needKeys[stage]}";

        if (lift)
        {
            liftBody.position = Vector3.MoveTowards(liftBody.position, stagePositions[stage], liftSpeed);
        }
    }

    public void DoorOpened()
    {
        if (!doorOpened)
        {
            stage++;
            lift = true;
            stagesObjects[stage - 1].gameObject.SetActive(false);
            stagesObjects[stage].gameObject.SetActive(true);
        }
    }
}
