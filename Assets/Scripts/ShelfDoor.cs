using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfDoor : MonoBehaviour
{
    [SerializeField] private Shelf parentShelf;

    private void Start()
    {
        PublicObjects.UseController.OnHover += UseController_OnHover;
    }

    private void UseController_OnHover(Transform t)
    {
        if (Input.GetKeyDown(KeyCode.E) && t == transform)
        {
            parentShelf.ChangeDoorState();
        }
    }

    private void OnDestroy()
    {
        PublicObjects.UseController.OnHover -= UseController_OnHover;
    }
}
