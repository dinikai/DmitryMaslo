using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftController : MonoBehaviour
{
    public KeyCode craftKey;
    public bool bodyShown;
    [SerializeField] private Animator bodyAnimator;

    private void Update()
    {
        if (Input.GetKeyDown(craftKey))
        {
            bodyShown = !bodyShown;
            bodyAnimator.SetBool("Opened", bodyShown);

            if (bodyShown)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            } else
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }
}
