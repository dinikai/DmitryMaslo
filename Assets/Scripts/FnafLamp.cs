using UnityEngine;

public class FnafLamp : Lamp
{
    [SerializeField] Generator generator;
    AudioSource audioSource;
    [SerializeField] AudioSource errorAudio;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        PublicObjects.UseController.OnHover += UseController_OnHover;
        generator.OnDown += Generator_OnDown;
    }

    private void Generator_OnDown(object sender, System.EventArgs e)
    {
        SetState(false);
    }

    private void UseController_OnHover(Transform t)
    {
        if (Input.GetKeyDown(KeyCode.E) && t == transform)
        {
            if (generator.IsWorking)
            {
                SetState(!State);
                audioSource.Play();
            } else
            {
                errorAudio.Play();
            }
        }
    }
}
