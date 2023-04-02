using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextController : MonoBehaviour
{
    private TextMeshProUGUI textMeshPro;
    private AudioSource letterAudio;
    public float letterDelay, showTime;
    public string text, writedText;
    public bool writing;

    private void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
        letterAudio = GetComponent<AudioSource>();
        StartCoroutine(TextCoroutine());
    }

    public void WriteText(string text)
    {
        this.text = text;
        writedText = "";
        textMeshPro.text = "";
        writing = true;
        StopAllCoroutines();
        StartCoroutine(TextCoroutine());
    }

    private IEnumerator TextCoroutine()
    {
        while (true)
        {
            if (writing)
            {
                for (int i = 0; i < text.Length; i++)
                {
                    writedText += text[i];
                    textMeshPro.text = writedText;
                    letterAudio.Play();
                    yield return new WaitForSeconds(letterDelay);
                }
                yield return new WaitForSeconds(showTime);

                for (int i = text.Length - 1; i >= 0; i--)
                {
                    writedText = writedText.Remove(i);
                    textMeshPro.text = writedText;
                    letterAudio.Play();
                    yield return new WaitForSeconds(letterDelay);
                }

                writing = false;
            }

            yield return new WaitForEndOfFrame();
        }
    }
}
