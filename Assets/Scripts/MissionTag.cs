using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Animations;

public class MissionTag : MonoBehaviour
{
    [SerializeField] Transform player, collectables;
    public Transform Destination;

    private void Start()
    {
        foreach (Transform collectable in collectables)
            collectable.GetComponent<Collectable>().OnCollect += (sender, e) => SetNewDestination();

        SetNewDestination();
    }

    private void Update()
    {
        
    }

    private void SetNewDestination()
    {
        var distances = new List<float>();
        foreach (Transform collectable in collectables)
            distances.Add(Vector3.Distance(player.position, collectable.position));

        float minDistance = distances.Min();
        Destination = collectables.GetChild(distances.IndexOf(minDistance));
        Destination.position = new Vector3(0, Destination.position.y, 0);

        ConstraintSource source = new ConstraintSource();
        source.sourceTransform = Destination;
        source.weight = 1;

        GetComponent<LookAtConstraint>().SetSource(0, source);
    }
}
