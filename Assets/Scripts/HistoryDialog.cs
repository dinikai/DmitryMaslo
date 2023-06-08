using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class HistoryDialog : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText, text;
    [SerializeField] private Animator dialogCamera, fadeImage;
    [SerializeField] private float letterDelay;
    [SerializeField] private AudioSource dialogAudio;
    [SerializeField] private List<HistoryScene> scenes;
    [SerializeField] private List<Transform> scenesObject;
    public List<string> dialog = new List<string>();
    public List<int> dialogSequence = new List<int>();
    public int dialogIndex = 0, sceneIndex = 0;
    public bool writing;
    private string writtenLetters = "";
    private List<string> names = new()
    {
        "Дима",
        "Эмиль"
    };

    private void Start()
    {
        StartCoroutine(DialogCoroutine());
        writing = true;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            writing = true;
        }
    }

    private IEnumerator DialogCoroutine()
    {
        while (true)
        {
            if (writing)
            {
                if (dialogSequence[dialogIndex] == 99)
                {
                    fadeImage.SetTrigger("Fade");
                }
                else if (dialogSequence[dialogIndex] == 100)
                {
                    SceneManager.LoadScene("PreGame");
                } else
                {
                    nameText.text = names[dialogSequence[dialogIndex]];
                    dialogCamera.SetInteger("Name", dialogSequence[dialogIndex]);
                }

                if (dialogSequence[dialogIndex] != 99 && dialogSequence[dialogIndex] != 100)
                {
                    for (int i = 0; i < dialog[dialogIndex].Length; i++)
                    {
                        writtenLetters += dialog[dialogIndex][i];
                        text.text = writtenLetters;
                        dialogAudio.Play();
                        yield return new WaitForSeconds(letterDelay);
                    }
                }
                writtenLetters = "";
                dialogIndex++;
                writing = false;
            }
            yield return new WaitForEndOfFrame();
        }
    }

    public IEnumerator NextScene()
    {
        sceneIndex++;
        if (sceneIndex == 1)
        {
            dialogCamera.enabled = false;
            yield return new WaitForEndOfFrame();
        }
        for (int i = 0; i < scenesObject.Count; i++)
        {
            scenesObject[i].position = scenes[sceneIndex].SceneObjects[i].Position;
            scenesObject[i].rotation = scenes[sceneIndex].SceneObjects[i].Rotation;
            scenesObject[i].localScale = scenes[sceneIndex].SceneObjects[i].Scale;
        }
    }
}
