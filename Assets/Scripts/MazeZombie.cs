using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MazeZombie : MonoBehaviour
{
    public Transform Target;
    private NavMeshAgent agent;
    [SerializeField] Transform collectables;
    [SerializeField] AudioSource beginAudio, runAudio, fairAudio;
    public bool IsChasing = false;
    private bool stepsFlag = false;
    public int CollectablesCollected = 0;
    private float chasingCollectables = 0;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        foreach (Transform collectable in collectables)
            collectable.GetComponent<Collectable>().OnCollect += Collectable_OnCollect;
    }

    private void Collectable_OnCollect(object sender, CollectableEventArgs e)
    {
        if (IsChasing)
        {
            chasingCollectables++;
            if (chasingCollectables >= 2)
            {
                chasingCollectables = 0;
                runAudio.Stop();
                IsChasing = false;
                foreach (Transform item in transform)
                    item.gameObject.SetActive(false);
            }
        }

        if (!IsChasing) CollectablesCollected++;

        if (CollectablesCollected % 8 == 0 && !IsChasing)
        {
            foreach (Transform item in transform)
                item.gameObject.SetActive(true);

            IsChasing = true;
            beginAudio.Play();
            runAudio.Play();
            fairAudio.Play();
        }
        e.ToDestroy.SetActive(false);
    }

    void Update()
    {
        if (IsChasing)
        {
            agent.SetDestination(Target.position);
        }
    }
}
