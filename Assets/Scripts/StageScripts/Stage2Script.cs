using System;
using UnityEngine;

public class Stage2Script : MonoBehaviour
{
    [SerializeField] private Transform lights;
    [SerializeField] private Door[] doorsToClose;
    [SerializeField] private PublicCollider publicCollider;
    [SerializeField] private AudioSource lightOn, lightOff, alert;

    private void Start()
    {
        PublicObjects.Elevator.OnArrived += Elevator_OnArrived;
        publicCollider.OnColliderEnter += PublicCollider_OnColliderEnter;
    }

    private void PublicCollider_OnColliderEnter(object sender, EventArgs e)
    {
        foreach (var door in doorsToClose)
        {
            door.SetDoorState(false);
            door.locked = true;
        }
        foreach (Transform light in lights)
        {
            light.GetComponent<Animator>().SetBool("On", false);
        }
        lightOff.Play();
        alert.Play();
        Destroy(publicCollider);
    }

    private void Elevator_OnArrived(object sender, ElevatorEventArgs e)
    {
        if (e.Stage == 1)
        {
            foreach (Transform light in lights)
            {
                light.GetComponent<Animator>().SetBool("On", true);
            }
            lightOn.Play();
        }
    }
}
