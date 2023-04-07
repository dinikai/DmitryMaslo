using System;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] AudioSource upAudio, downAudio;
    public event EventHandler OnDown, OnUp;
    public bool Pressed;

    private void Start()
    {
        PublicObjects.UseController.OnHover += UseController_OnHover;
    }

    private void Update()
    {
        if (PublicObjects.UseController.Hover)
        {
            if (PublicObjects.UseController.LastTransform == transform)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    animator.SetBool("Switch", true);
                    Pressed = true;
                    if (OnDown != null) OnDown(this, new());
                    upAudio.Play();
                }
                if (Input.GetKeyUp(KeyCode.E))
                {
                    animator.SetBool("Switch", false);
                    Pressed = false;
                    if (OnUp != null) OnUp(this, new());
                    downAudio.Play();
                }
            }
        } else if (Pressed)
        {
            animator.SetBool("Switch", false);
            Pressed = false;
            if (OnUp != null) OnUp(this, new());
            downAudio.Play();
        }
    }

    private void UseController_OnHover(Transform t)
    {
        
    }
}
