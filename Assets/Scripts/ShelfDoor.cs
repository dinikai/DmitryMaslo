using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfDoor : MonoBehaviour
{
    private UseController useController;
    [SerializeField] private Shelf parentShelf;

    private void Awake()
    {
        useController = GameObject.FindGameObjectWithTag("UseController").GetComponent<UseController>();
        useController.OnHover += UseController_OnHover;
    }

    private void UseController_OnHover(Transform t)
    {
        if (Input.GetKeyDown(KeyCode.E) && t == transform)
        {
            parentShelf.ChangeDoorState();
        }
    }
}
