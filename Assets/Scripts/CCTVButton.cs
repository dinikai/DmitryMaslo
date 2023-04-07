using UnityEngine;

public class CCTVButton : MonoBehaviour
{
    [SerializeField] private CCTVController controller;
    public int CameraIndex;
    Animator animator;

    private void Start()
    {
        PublicObjects.UseController.OnHover += UseController_OnHover;
        animator = GetComponent<Animator>();
    }

    private void UseController_OnHover(Transform t)
    {
        if (Input.GetKeyDown(KeyCode.E) && t == transform)
        {
            controller.UseCamera(CameraIndex);
            animator.SetTrigger("Press");
        }
    }
}
