using UnityEngine;

public class HideLight : MonoBehaviour
{
    Light light;

    private void Awake()
    {
        light = transform.GetChild(0).GetComponent<Light>();
    }

    private void OnPreCull() => light.enabled = false;
    private void OnPreRender() => light.enabled = false;
    private void OnPostRender() => light.enabled = false;
}
