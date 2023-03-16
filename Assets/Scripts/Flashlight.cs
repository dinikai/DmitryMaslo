using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField] private AudioSource switchSound;
    [SerializeField] private GameObject[] flashlightLights;
    [SerializeField] private Material bloomFlashlightMaterial, offFlashlightMaterial;
    public KeyCode flashlightKey;
    
    private void Update()
    {
        if (Input.GetKeyDown(flashlightKey))
        {
            switchSound.Play();
            /*materialFlag = !materialFlag;
            flashlightRenderer.material = materialFlag ? bloomFlashlightMaterial : offFlashlightMaterial;*/
            foreach (var light in flashlightLights)
            {
                light.SetActive(!light.activeSelf);
            }
        }
    }
}
