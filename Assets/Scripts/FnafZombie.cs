using System;
using UnityEngine;
using UnityEngine.AI;

public class FnafZombie : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    [SerializeField] Transform player, homePoint;
    public bool Lost = false, CanHide = false, GoingToHome;
    [SerializeField] PublicCollider loseTrigger, hideZone;
    [SerializeField] float attackSpeed, homeSpeed, speedIncrease;
    [SerializeField] AudioSource stepsAudio, staticAudio, jumpscareAudio;
    bool jumpscared = false;
    [SerializeField] GameObject jumpscareZombie;
    [SerializeField] FnafLamp fnafLamp;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        loseTrigger.OnColliderEnter += LoseTrigger_OnColliderEnter;
    }

    private void LoseTrigger_OnColliderEnter(object sender, EventArgs e)
    {
        if (fnafLamp.State)
        {
            GoingToHome = true;
            attackSpeed += speedIncrease;
            stepsAudio.Play();
        } else
        {
            Lost = true;
            navMeshAgent.speed = 20;
            staticAudio.Play();
            Destroy(loseTrigger.gameObject);
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

        if (Vector3.Distance(transform.position, player.position) < 10 && !jumpscared)
        {
            jumpscared = true;
            jumpscareAudio.Play();
            jumpscareZombie.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
