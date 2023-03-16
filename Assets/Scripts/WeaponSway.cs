using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSway : MonoBehaviour
{
    [SerializeField] private float amount, smoothAmount;
    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.localPosition;
    }

    private void Update()
    {
        float x = -Input.GetAxisRaw("Mouse X") * amount;
        float y = -Input.GetAxisRaw("Mouse Y") * amount;

        Vector3 finalPosition = new Vector3(x, y, 0);
        transform.localPosition = Vector3.Lerp(transform.localPosition, finalPosition + initialPosition, Time.deltaTime * smoothAmount);
    }
}
