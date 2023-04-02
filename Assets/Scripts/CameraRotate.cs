using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    [SerializeField] private Transform player;
    private Vector3 offset;
    public float sens, xRot, yRot;
    public int cameraType;
    [SerializeField] private CraftController craftController;
    public bool canCraft, canRotate;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        offset = player.transform.position - transform.position;
    }

    private void Update()
    {
        xRot -= Input.GetAxisRaw("Mouse Y") * sens;
        yRot += Input.GetAxisRaw("Mouse X") * sens;

        xRot = Mathf.Clamp(xRot, -90, 90);

        canRotate = true;
        if (canCraft)
            canRotate = !craftController.bodyShown;

        if (canRotate)
        {
            player.rotation = Quaternion.Euler(player.rotation.x, yRot, 0);
            transform.rotation = Quaternion.Euler(xRot, yRot, 0);

            float desiredAngle = player.transform.eulerAngles.y;
            Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);
            transform.position = player.transform.position - (rotation * offset);
        }
    }
}
