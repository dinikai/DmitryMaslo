using System;
using UnityEngine;
using UnityEngine.AI;

public class FnafZombie : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    [SerializeField] Transform player, homePoint;
    public bool Lost = false, CanHide = false, GoingToHome;
    [SerializeField] PublicCollider loseTrigger, hideZone;
    [SerializeField] float attackSpeed, homeSpeed;
    [SerializeField] AudioSource stepsAudio, downAudio;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        loseTrigger.OnColliderEnter += LoseTrigger_OnColliderEnter;
    }

    private void LoseTrigger_OnColliderEnter(object sender, EventArgs e)
    {
        if (!hideZone.InCollider)
        {
            Lost = true;
            navMeshAgent.speed = 30;
            Destroy(loseTrigger.gameObject);
        } else
        {
            GoingToHome = true;
            stepsAudio.Play();
        }
    }

    private void Update()
    {
        if (!GoingToHome)
        {
            if (!Lost) navMeshAgent.speed = attackSpeed;
            navMeshAgent.SetDestination(player.position);
        } else if (Vector3.Distance(transform.position, homePoint.position) < 5)
        {
            GoingToHome = false;
        } else
        {
            navMeshAgent.speed = homeSpeed;
            navMeshAgent.SetDestination(homePoint.position);
        }
    }
}
