using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    [Tooltip("Run action once time and delete trigger")]
    public bool triggerOnce;
    [SerializeField] private float runDelay;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            IEnumerator Action()
            {
                yield return new WaitForSeconds(runDelay);

                RunTrigger();
                if (triggerOnce)
                    Destroy(gameObject);
            }
            StartCoroutine(Action());
        }
    }

    public virtual void RunTrigger()
    {

    }
}