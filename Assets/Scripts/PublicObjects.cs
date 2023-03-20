using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PublicObjects : MonoBehaviour
{
    public static UseController UseController { get; set; }
    public static NoticeController NoticeController { get; set; }
    public static TextController TextController { get; set; }
    public static Elevator Elevator { get; set; }
    public static AudioClip doorOpen, doorLocked;
    public AudioClip mDoorOpen, mDoorLocked;

    private void Awake()
    {
        UseController = GameObject.FindGameObjectWithTag("UseController").GetComponent<UseController>();
        NoticeController = GameObject.FindGameObjectWithTag("NoticeController").GetComponent<NoticeController>();
        TextController = GameObject.FindGameObjectWithTag("Text").GetComponent<TextController>();
        Elevator = GameObject.FindGameObjectWithTag("Elevator").GetComponent<Elevator>();
        doorOpen = mDoorOpen;
        doorLocked = mDoorLocked;
    }
}