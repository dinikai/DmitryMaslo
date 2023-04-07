using UnityEngine;
using UnityEngine.AI;

public class FnafZombie : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    [SerializeField] Transform player;
    public bool Lost = false;
    [SerializeField] PublicCollider loseTrigger;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        loseTrigger.OnColliderEnter += LoseTrigger_OnColliderEnter;
    }

    private void LoseTrigger_OnColliderEnter(object sender, System.EventArgs e)
    {
        Lost = true;
        navMeshAgent.speed = 20;
        Destroy(loseTrigger.gameObject);
    }

    private void Update()
    {
        navMeshAgent.SetDestination(player.position);
    }
}
