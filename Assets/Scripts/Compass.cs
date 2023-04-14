using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Compass : MonoBehaviour
{
    [SerializeField] Transform player, collectables;
    public Vector3 Destination;

    private void Start()
    {
        foreach (Transform collectable in collectables)
            collectable.GetComponent<Collectable>().OnCollect += (sender, e) => SetNewDestination();

        SetNewDestination();
    }

    private void Update()
    {
        SetNewDestination();
        Vector3 destination = Destination;
        destination.y = 0;
        transform.LookAt(destination);
        transform.eulerAngles += new Vector3(0, 0, player.rotation.y);
    }

    private void SetNewDestination()
    {
        var distances = new List<float>();
        foreach (Transform collectable in collectables)
            distances.Add(Vector3.Distance(player.position, collectable.position));

        float minDistance = distances.Min();
        Destination = collectables.GetChild(distances.IndexOf(minDistance)).position;
    }
}
