using System.Collections.Generic;
using UnityEngine;

public class MazeEnd : MonoBehaviour
{
    [SerializeField] private MazeZombie zombie;
    [SerializeField] private List<PublicCollider> doorsColliders;
    [SerializeField] private Vector3 teleportPosition;
    [SerializeField] private Rigidbody player;
    [SerializeField] private GameObject intermediateStage;

    private void Start()
    {
        doorsColliders.ForEach(collider => collider.OnColliderEnter += (sender, e) =>
        {
            player.position = teleportPosition;
            zombie.StopChasing();
            intermediateStage.SetActive(true);
        });
    }
}
