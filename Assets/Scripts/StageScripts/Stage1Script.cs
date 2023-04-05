using System;
using UnityEngine;

public class Stage1Script : MonoBehaviour
{
    [SerializeField] private PublicCollider lightOnCollider, lightOffCollider;
    [SerializeField] private Transform lights;
    [SerializeField] private AudioSource lightOn, lightOff, labTone;

    private void Start()
    {
        lightOffCollider.OnColliderEnter += LightOffCollider_OnColliderEnter;
        lightOnCollider.OnColliderEnter += LightOnCollider_OnColliderEnter;
    }

    private void LightOnCollider_OnColliderEnter(object sender, EventArgs e)
    {
        foreach (Transform light in lights)
        {
            light.GetComponent<Animator>().SetBool("On", true);
        }
        lightOn.Play();
        Destroy(lightOnCollider);
    }

    private void LightOffCollider_OnColliderEnter(object sender, EventArgs e)
    {
        foreach (Transform light in lights)
        {
            light.GetComponent<Animator>().SetBool("On", false);
        }
        lightOff.Play();
        labTone.Play();
        Destroy(lightOffCollider);
    }
}
