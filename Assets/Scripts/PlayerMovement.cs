using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    public float walkSpeed, runSpeed, fallSpeed, stamina = 1f, staminaIncrement, staminaDecrement, acceleration, velocity;
    public float xAxis, zAxis;
    [SerializeField] private Animator animator, modelAnimator;
    [SerializeField] private CraftController craftController;
    public bool canCraft, canWalk;
    private float blend;
    public float blendIncrease;
    private PhotonView photonView;
    [SerializeField] PlayerInfo playerInfo;
    [SerializeField] Image staminaBar;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        photonView = GetComponent<PhotonView>();

        if (playerInfo.IsMultiplayer)
        {
            if (!photonView.IsMine)
            {
                Destroy(GetComponent<PlayerMovement>());
            }
        }

        /*if (SceneConnector.playerPosition != Vector3.zero)
        {
            transform.position = SceneConnector.playerPosition;
        }*/
    }

    private void Update()
    {
        if (canCraft)
        {
            if (!craftController.bodyShown)
                Move();
        }
        else
            Move();
    }

    private void Move()
    {

        xAxis = Input.GetAxis("Horizontal");
        zAxis = Input.GetAxis("Vertical");

        float speed = Input.GetKey(KeyCode.LeftShift) && stamina > 0f ? runSpeed : walkSpeed;
        staminaBar.fillAmount = stamina;

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
            }
            else // Walk
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
        }
        else // Idle
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

        float localSpeed = speed;
        if (!canWalk)
            localSpeed = 0;
        //Vector3 moveVector = transform.TransformDirection(new Vector3(xAxis, 0, zAxis)) * localSpeed * Time.fixedDeltaTime;
        rb.velocity = transform.TransformDirection(new Vector3(xAxis * localSpeed * Time.fixedDeltaTime, rb.velocity.y, zAxis * localSpeed * Time.fixedDeltaTime));

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
