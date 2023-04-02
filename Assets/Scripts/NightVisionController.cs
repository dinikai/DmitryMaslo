using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class NightVisionController : MonoBehaviour
{
    [SerializeField] private Color boostedLightColor;
    private Color defaultLightColor;
    public bool visionEnabled, canEnable = true;
    [SerializeField] private KeyCode key;
    [SerializeField] private PostProcessVolume volume;
    [SerializeField] private AudioSource enableAudio, disableAudio;
    [SerializeField] private float staminaInc, staminaDec, visionAnimationDuration;
    [SerializeField] private Image visionBar;
    [SerializeField] private Animator visionBarAnimator;

    private void Start()
    {
        defaultLightColor = RenderSettings.ambientLight;
        canEnable = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(key) && canEnable)
        {
            visionEnabled = !visionEnabled;
            ChangeVision(visionEnabled);
        }
    }

    private void FixedUpdate()
    {
        if (visionEnabled)
        {
            if (volume.weight < 1) volume.weight += visionAnimationDuration;
            if (visionBar.fillAmount > 0) visionBar.fillAmount -= staminaDec;
            else CantEnable();
        }
        else
        {
            if (volume.weight > 0) volume.weight -= visionAnimationDuration;
        }
    }

    private void ChangeVision(bool vision)
    {
        RenderSettings.ambientLight = visionEnabled ? boostedLightColor : defaultLightColor;
        if (visionEnabled) enableAudio.Play();
        else disableAudio.Play();
    }

    private void CanEnable()
    {
        //visionBarAnimator.SetTrigger("Blink");
    }

    private void CantEnable()
    {
        visionEnabled = false;
        canEnable = false;
        ChangeVision(visionEnabled);
    }
}
