using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController characterController;
    public float walkSpeed, runSpeed, fallSpeed, stamina = 1f, staminaIncrement, staminaDecrement, acceleration, velocity;
    private float xAxis, zAxis;
    [SerializeField] private Image staminaBar;
    [SerializeField] private Animator animator, modelAnimator;
    [SerializeField] private CraftController craftController;
    public bool canCraft, canWalk;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();

        /*if (SceneConnector.playerPosition != Vector3.zero)
        {
            transform.position = SceneConnector.playerPosition;
        }*/
    }

    private void Update()
    {
        xAxis = Input.GetAxisRaw("Horizontal");
        zAxis = Input.GetAxisRaw("Vertical");

        float speed = Input.GetKey(KeyCode.LeftShift) && stamina > 0f ? runSpeed : walkSpeed;
        staminaBar.fillAmount = stamina;

        canWalk = true;
        if (canCraft)
            canWalk = !craftController.bodyShown;

        if ((xAxis != 0 || zAxis != 0) && canWalk)
        {
            if (Input.GetKey(KeyCode.LeftShift)) // Run
            {
                animator.SetBool("Walk", false);
                animator.SetBool("Run", true);
                if (velocity < 1f)
                {
                    velocity += acceleration * Time.deltaTime;
                }
            } else // Walk
            {
                animator.SetBool("Walk", true);
                animator.SetBool("Run", false);
                if (velocity < .5f)
                {
                    velocity += acceleration * Time.deltaTime;
                }
                if (velocity > .55f)
                {
                    velocity -= acceleration * Time.deltaTime;
                }
            }
        } else // Idle
        {
            animator.SetBool("Walk", false);
            animator.SetBool("Run", false);
            if (velocity > 0f)
            {
                velocity -= acceleration * Time.deltaTime;
            }
        }

        if (velocity < 0f)
            velocity = 0f;

        modelAnimator.SetFloat("Velocity", velocity);

        float yVector = characterController.isGrounded ? 0 : fallSpeed;

        float localSpeed = speed;
        if (!canWalk)
            localSpeed = 0;
        Vector3 moveVector = transform.TransformDirection(new Vector3(xAxis, 0, zAxis)) * localSpeed * Time.deltaTime;
        moveVector.y -= yVector;
        characterController.Move(moveVector);
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftShift) && (xAxis != 0 || zAxis != 0) && canWalk)
        {
            if (stamina > 0f) stamina -= staminaDecrement;
        }
        else
        {
            if (stamina < 1f) stamina += staminaIncrement;
        }
    }
}
