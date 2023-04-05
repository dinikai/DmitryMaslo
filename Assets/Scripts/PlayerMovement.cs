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
    private float blend;
    public float blendIncrease;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();

        /*if (SceneConnector.playerPosition != Vector3.zero)
        {
            transform.position = SceneConnector.playerPosition;
        }*/
    }

    private void FixedUpdate()
    {
        xAxis = Input.GetAxis("Horizontal");
        zAxis = Input.GetAxis("Vertical");

        float speed = Input.GetKey(KeyCode.LeftShift) && stamina > 0f ? runSpeed : walkSpeed;
        staminaBar.fillAmount = stamina;

        canWalk = true;
        if (canCraft)
            canWalk = !craftController.bodyShown;

        if ((xAxis == 1 || zAxis == 1) || (xAxis == -1 || zAxis == -1) && canWalk)
        {
            animator.SetBool("Walk", true);
            blend += blendIncrease;

            if (Input.GetKey(KeyCode.LeftShift) && stamina > 0f) // Run
            {
                if (blend > 1)
                    blend = 1;
                animator.SetFloat("Blend", blend);
                if (velocity < 1f)
                {
                    velocity += acceleration * Time.fixedDeltaTime;
                }
            } else // Walk
            {
                if (blend > .5f)
                    blend = .5f;
                animator.SetFloat("Blend", blend);
                if (velocity < .5f)
                {
                    velocity += acceleration * Time.fixedDeltaTime;
                }
                if (velocity > .55f)
                {
                    velocity -= acceleration * Time.fixedDeltaTime;
                }
            }
        } else // Idle
        {
            blend -= blendIncrease;
            if (blend < 0f)
                blend = 0f;

            animator.SetFloat("Blend", blend);
            animator.SetBool("Walk", false);
            if (velocity > 0f)
            {
                velocity -= acceleration * Time.fixedDeltaTime;
            }
        }

        modelAnimator.SetFloat("Velocity", velocity);

        float yVector = characterController.isGrounded ? 0 : fallSpeed;

        float localSpeed = speed;
        if (!canWalk)
            localSpeed = 0;
        Vector3 moveVector = transform.TransformDirection(new Vector3(xAxis, 0, zAxis)) * localSpeed * Time.fixedDeltaTime;
        moveVector.y -= yVector;
        characterController.Move(moveVector);

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
