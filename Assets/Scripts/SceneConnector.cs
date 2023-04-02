using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneConnector : MonoBehaviour
{
    public static Vector3 playerPosition = Vector3.zero;
    public string scene;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerPosition = other.transform.position;
            SceneManager.LoadScene(scene);
        }
    }
}
