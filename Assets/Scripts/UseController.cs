using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseController : MonoBehaviour
{
    [ColorUsage(false, true)] public Color useEmissionColor;
    [SerializeField] private GameObject hintObject;
    [SerializeField] private float maxDistance;
    public delegate void HoverDelegate(Transform t);
    public event HoverDelegate OnHover;
    private GameObject lastUsable;

    private void Start()
    {
        hintObject.SetActive(false);
    }

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, maxDistance))
        {
            Usable usable = hit.transform.GetComponent<Usable>();
            if (usable)
            {
                OnHover(hit.transform);
                hintObject.SetActive(true);
                lastUsable = hit.transform.gameObject;
                if (usable.changeEmission)
                {
                    MeshRenderer meshRenderer = hit.transform.GetComponent<MeshRenderer>();
                    meshRenderer.material.SetColor("_EmissionColor", useEmissionColor);
                    meshRenderer.material.EnableKeyword("_EMISSION");
                }
            } else
            {
                hintObject.SetActive(false);
                if (lastUsable != null)
                {
                    if (lastUsable.GetComponent<Usable>().changeEmission)
                    {
                        MeshRenderer meshRenderer = lastUsable.GetComponent<MeshRenderer>();
                        meshRenderer.material.SetColor("_EmissionColor", Color.black);
                        meshRenderer.material.EnableKeyword("_EMISSION");
                    }
                }
            }
        } else
        {
            hintObject.SetActive(false);
            if (lastUsable != null)
            {
                if (lastUsable.GetComponent<Usable>().changeEmission)
                {
                    MeshRenderer meshRenderer = lastUsable.GetComponent<MeshRenderer>();
                    meshRenderer.material.SetColor("_EmissionColor", Color.black);
                    meshRenderer.material.EnableKeyword("_EMISSION");
                }
            }
        }
    }
}
