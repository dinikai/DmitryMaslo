using UnityEngine;
using System.Linq;

public class Radar3 : MonoBehaviour
{
    [SerializeField] private KeyCode key;
    [SerializeField] GameObject mainCamera, radarCamera, weaponParent;
    [SerializeField] AudioSource openAudio, closeAudio;
    public bool IsOpened = false;
    [SerializeField] private Color boostedAmbientColor;
    [SerializeField] private Kick kickController;
    [SerializeField] private PlayerMovement playerMovement;

    private void Update()
    {
        if (Input.GetKeyDown(key))
        {
            IsOpened = !IsOpened;
            if (IsOpened)
            {
                openAudio.Play();
                //RenderSettings.ambientLight = boostedAmbientColor;
            } else
            {
                closeAudio.Play();
                //RenderSettings.ambientLight = defaultAmbientColor;
            }
            radarCamera.SetActive(IsOpened);
            mainCamera.SetActive(!IsOpened);
            PublicObjects.UseController.gameObject.SetActive(!IsOpened);
            weaponParent.SetActive(!IsOpened);
            kickController.enabled = !IsOpened;
            playerMovement.canWalk = !IsOpened;

            PublicObjects.Fade.SetTrigger("Fade");
        }
    }
}
