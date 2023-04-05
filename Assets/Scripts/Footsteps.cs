using UnityEngine;

public class Footsteps : MonoBehaviour
{
    [SerializeField] private AudioSource footsteps;
    [SerializeField] private AudioClip[] stepClips;

    public void StepSound()
    {
        footsteps.pitch = Random.Range(0.9f, 1f);
        footsteps.clip = stepClips[Random.Range(0, stepClips.Length)];
        footsteps.Play();
    }
}
