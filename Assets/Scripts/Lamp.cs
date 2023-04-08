using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour
{
    [SerializeField] GameObject lightObject;
    [SerializeField] MeshRenderer headRenderer;
    [SerializeField] Material onMaterial, offMaterial;
    public bool State;

    public void SetState(bool state)
    {
        State = state;
        headRenderer.material = state ? onMaterial : offMaterial;
        lightObject.SetActive(state);
    }
}
