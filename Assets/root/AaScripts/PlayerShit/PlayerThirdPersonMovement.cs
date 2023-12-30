using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerThirdPersonMovement : MonoBehaviour
{

    //Components of Player
    PlayerInput playerInput;
    Rigidbody rb;
    PlayerGroundCheck pGroundCheck;
    PlayerJump pJump;
    PlayerHook pHook;

    //Movement variables
    [SerializeField] float acceleration, airAcceleration, deceleration, maxSpeed;


    [SerializeField] bool changingDirection;

    //public
    public bool hasStopedMidAir;


    private void Awake()
    {
        //Get Components
        playerInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();
        pGroundCheck = GetComponent<PlayerGroundCheck>();
        pJump = GetComponent<PlayerJump>();
        pHook = GetComponent<PlayerHook>();
    }
    void Start()
    {


        //PlayerCanMove
        GameManager.Instance.canPlayerMove = true;
    }
    private Vector2 GetInputsX()
    {
        //This will get the horizontal movement
        Vector2 inputs;
        inputs = playerInput.actions["XMovement"].ReadValue<Vector2>();
        return inputs;
    }



    private void FixedUpdate()
    {
        if (!pHook.isHooking && GameManager.Instance.canPlayerMove)
        {
            Movement();
        }
    }


    private void Movement()
    {
        //check if you are changing direcction
        changingDirection = (pGroundCheck.isPlayerGrounded && (rb.velocity.x < 0 && GetInputsX().x > 0) || (rb.velocity.x > 0 && GetInputsX().x < 0));


        //we set a movement aceleration for the grounded player and anotherone for airplayer

        if (pGroundCheck.isPlayerGrounded) rb.AddForce(new Vector2(GetInputsX().x * acceleration, 0f));
        else rb.AddForce(new Vector2(GetInputsX().x * airAcceleration, 0f));




        // Since addForce does not limit the speed, we need to limit it.
        if (Mathf.Abs(rb.velocity.x) > maxSpeed) rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * maxSpeed, rb.velocity.y);


        //DRAG



        if (GameManager.Instance.thirdPersonCam)
        {
            if (pGroundCheck.isPlayerGrounded) rb.AddForce(new Vector2(-GetInputsX().y * acceleration, 0f));
            else rb.AddForce(new Vector2(-GetInputsX().y * airAcceleration, 0f));

            if ((Mathf.Abs(-GetInputsX().y) < 0.4 && !pJump.isJumping) && (Mathf.Abs(GetInputsX().x) < 0.4 && !pJump.isJumping) || changingDirection) rb.drag = deceleration;
            else rb.drag = 0f;


        }
        else
        {
            if (pGroundCheck.isPlayerGrounded && !GetComponent<PlayerJump>().isHoldingJump)
            {
                //Debug.Log(changingDirection);
                //if the player stops moving we want the drag to be= to the deceleration.

                if ((Mathf.Abs(GetInputsX().x) < 0.4 && !pJump.isJumping) || changingDirection) rb.drag = deceleration;
                else rb.drag = 0f;

            }
        }



    }

}


