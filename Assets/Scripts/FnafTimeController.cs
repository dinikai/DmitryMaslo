using System.Collections;
using TMPro;
using UnityEngine;

public class FnafTimeController : MonoBehaviour
{
    [SerializeField] TextMeshPro hoursText, minutesText;
    [SerializeField] GameObject colon;
    [SerializeField] AudioSource winNoise;
    public float Time, TimeIncreaseSeconds, WinTime;
    [SerializeField] float timeDelay, winNoiseTime;
    int seconds, hours, minutes;

    private void Start()
    {
        IEnumerator TimeCoroutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(timeDelay);
                seconds++;
                colon.SetActive(!colon.activeSelf);
                if (seconds % TimeIncreaseSeconds == 0)
                {
                    Time++;
                    minutes++;
                    if (Time >= winNoiseTime)
                        winNoise.volume = (Time - winNoiseTime) / (WinTime - winNoiseTime);
                    if (minutes >= 60)
                    {
                        minutes = 0;
                        hours++;
                    }
                    hoursText.text = hours < 10 ? $"0{hours}" : hours.ToString();
                    minutesText.text = minutes < 10 ? $"0{minutes}" : minutes.ToString();
                }
            }
        }
        StartCoroutine(TimeCoroutine());
    }
}
