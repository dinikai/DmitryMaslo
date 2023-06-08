using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MazeZombie : MonoBehaviour
{
    public Transform Target;
    private NavMeshAgent agent;
    [SerializeField] Transform collectables;
    [SerializeField] AudioSource beginAudio, runAudio, fairAudio, tempFairAudio, unlockAudio;
    [SerializeField] List<Door> doors;
    public bool IsChasing = false;
    public int CollectablesCollected = 0;
    private float chasingCollectables = 0, collectablesCount = 0;
    private int toStartChasing, toStopChasing;
    public event EventHandler OnCollect;
    public int NeedToCollect;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        foreach (Transform collectable in collectables)
            collectable.GetComponent<Collectable>().OnCollect += Collectable_OnCollect;

        toStartChasing = UnityEngine.Random.Range(3, 6);
    }

    private void Collectable_OnCollect(object sender, CollectableEventArgs e)
    {
        if (IsChasing)
        {
            chasingCollectables++;
            if (chasingCollectables >= toStopChasing)
            {
                chasingCollectables = 0;
                runAudio.Stop();
                tempFairAudio.Stop();
                IsChasing = false;
                foreach (Transform item in transform)
                    item.gameObject.SetActive(false);
            }
        }

        if (!IsChasing)
        {
            CollectablesCollected++;
            collectablesCount++;

            if (NeedToCollect == CollectablesCollected)
            {
                doors.ForEach(door => door.locked = false);
                unlockAudio.Play();
            }
        }

        if (collectablesCount >= toStartChasing && !IsChasing)
        {
            foreach (Transform item in transform)
                item.gameObject.SetActive(true);

            IsChasing = true;
            beginAudio.Play();
            runAudio.Play();
            fairAudio.Play();
            tempFairAudio.Play();
            collectablesCount = 0;
            toStopChasing = UnityEngine.Random.Range(2, 4);
            toStartChasing = UnityEngine.Random.Range(3, 6);
        }
        e.ToDestroy.SetActive(false);

        if (OnCollect != null) OnCollect(this, new());
    }

    void Update()
    {
        if (IsChasing)
        {
            agent.SetDestination(Target.position);
        }
    }
}
