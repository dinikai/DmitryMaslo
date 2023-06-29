using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PublicObjects : MonoBehaviour
{
    public bool Set;

    public static UseController UseController { get; set; }
    public static NoticeController NoticeController { get; set; }
    public static TextController TextController { get; set; }
    public static Elevator Elevator { get; set; }

    public static AudioClip doorOpen, doorLocked;
    public AudioClip mDoorOpen, mDoorLocked;
    public static AudioSource equipAudio;
    public AudioSource mEquipAudio;
    public static Animator Fade;
    [SerializeField] private Animator fade;
    public static Image StaminaBar;
    [SerializeField] private Image staminaBar;

    private void Awake()
    {
        if (!Set)
            return;

        if (GameObject.FindGameObjectsWithTag("UseController").Length != 0)
            UseController = GameObject.FindGameObjectWithTag("UseController").GetComponent<UseController>();
        if (GameObject.FindGameObjectsWithTag("NoticeController").Length != 0)
            NoticeController = GameObject.FindGameObjectWithTag("NoticeController").GetComponent<NoticeController>();
        if (GameObject.FindGameObjectsWithTag("Text").Length != 0)
            TextController = GameObject.FindGameObjectWithTag("Text").GetComponent<TextController>();
        if (SceneManager.GetActiveScene().name == "Game") Elevator = GameObject.FindGameObjectWithTag("Elevator").GetComponent<Elevator>();

        doorOpen = mDoorOpen;
        doorLocked = mDoorLocked;
        equipAudio = mEquipAudio;
        Fade = fade;
        StaminaBar = staminaBar;
    }
}
