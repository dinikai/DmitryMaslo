using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallSkeletonAudio : MonoBehaviour
{
    public void Play()
    {
        GetComponent<AudioSource>().Play();
    }

    public void Stop()
    {
        GetComponent<AudioSource>().Stop();
    }
}
