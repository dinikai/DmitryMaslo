using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicTexture : MonoBehaviour
{
    public Texture texture;

    private void Start()
    {
        GetComponent<Renderer>().material.SetTexture("_MainTex", texture);
    }
}
