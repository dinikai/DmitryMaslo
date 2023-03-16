using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class HistoryDialog : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dialog1, dialog2;
    [SerializeField] private Animator name1, name2, fadeImage;
    [SerializeField] private float letterDelay;
    [SerializeField] private AudioSource dialogAudio;
    [SerializeField] private List<HistoryScene> scenes; // 0 - Camera, 1 - Dima, 2 - Emil
    [SerializeField] private List<Transform> scenesObject;
    public List<string> dialog = new List<string>();
    public List<int> dialogSequence = new List<int>();
    public int dialogIndex = 0, sceneIndex = 0;
    public bool writing;
    private string writtenLetters = "";

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
                if (dialogSequence[dialogIndex] == 0)
                {
                    name1.SetBool("Active", true);
                    name2.SetBool("Active", false);
                }
                else if (dialogSequence[dialogIndex] == 1)
                {
                    name1.SetBool("Active", false);
                    name2.SetBool("Active", true);
                }
                else if (dialogSequence[dialogIndex] == 99)
                {
                    fadeImage.SetTrigger("Fade");
                }
                else if (dialogSequence[dialogIndex] == 100)
                {
                    SceneManager.LoadScene("PreGame");
                }

                if (dialogSequence[dialogIndex] != 99 && dialogSequence[dialogIndex] != 100)
                {
                    for (int i = 0; i < dialog[dialogIndex].Length; i++)
                    {
                        writtenLetters += dialog[dialogIndex][i];
                        if (dialogSequence[dialogIndex] == 0)
                        {
                            dialog1.text = writtenLetters;
                        }
                        else if (dialogSequence[dialogIndex] == 1)
                        {
                            dialog2.text = writtenLetters;
                        }
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

    public void NextScene()
    {
        sceneIndex++;
        for (int i = 0; i < scenesObject.Count; i++)
        {
            scenesObject[i].position = scenes[sceneIndex].SceneObjects[i].Position;
            scenesObject[i].rotation = scenes[sceneIndex].SceneObjects[i].Rotation;
            scenesObject[i].localScale = scenes[sceneIndex].SceneObjects[i].Scale;
        }
    }
}
