using System;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public event EventHandler<CollectableEventArgs> OnCollect;
    [SerializeField] AudioSource grabAudio;

    private void Start()
    {
        PublicObjects.UseController.OnHover += UseController_OnHover;
    }

    private void UseController_OnHover(Transform t)
    {
        if (Input.GetKeyDown(KeyCode.E) && t == transform)
        {
            OnCollect?.Invoke(this, new(gameObject));
            grabAudio.Play();
        }
    }
}

public class CollectableEventArgs : EventArgs
{
    public GameObject ToDestroy { get; set; }

    public CollectableEventArgs(GameObject toDestroy) => ToDestroy = toDestroy;
}