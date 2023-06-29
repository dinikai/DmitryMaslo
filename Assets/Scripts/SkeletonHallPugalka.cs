using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonHallPugalka : MonoBehaviour
{
    [SerializeField] private List<PublicCollider> triggers;
    [SerializeField] private Animator skeletonAnimator;

    private void Start()
    {
        triggers.ForEach((trigger, i) =>
        {
            trigger.OnColliderEnter += (sender, e) =>
            {
                Debug.Log($"Pugalka{i}");
                skeletonAnimator.SetTrigger($"Pugalka{i}");
                Destroy((PublicCollider)sender);
            };
        });
    }
}
