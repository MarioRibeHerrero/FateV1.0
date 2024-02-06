using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //Components of Player
    PlayerInput playerInput;
    Rigidbody rb;
    PlayerGroundCheck pGroundCheck;
    PlayerJump pJump;
    PlayerHook pHook;
    PlayerManager pManager;
    

    //Movement variables
    [SerializeField] float acceleration, airAcceleration, deceleration, maxSpeed;


    [SerializeField] bool changingDirection;

    [SerializeField] GameObject bodyAnim;

    //public
    public bool hasStopedMidAir;

    public Vector2 inputs;
    private void Awake()
    {
        //Get Components
        playerInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();
        pGroundCheck = GetComponent<PlayerGroundCheck>();
        pJump = GetComponent<PlayerJump>();
        pHook = GetComponent<PlayerHook>();
        pManager = GetComponent<PlayerManager>();




    }





    private void FixedUpdate()
    {
        if (!pHook.isHooking && pManager.canPlayerMove)
        {
            Movement();
        }
    }
    private void Update()
    {
        inputs = playerInput.actions["Movement"].ReadValue<Vector2>();


        if (!pHook.isFallingFromHook && !pHook.isHooking && !pGroundCheck.isPlayerGrounded && Mathf.Approximately(inputs.x, 0f))
        {
            rb.velocity = new Vector3(0f, rb.velocity.y, 0f);
        }

    }

    private void Movement()
    {
        //check if you are changing direcction

        if(!GameManager.Instance.thirdPersonCam) changingDirection = pGroundCheck.isPlayerGrounded && (rb.velocity.x < 0 && inputs.x > 0) || (rb.velocity.x > 0 && inputs.x < 0);

        //we set a movement aceleration for the grounded player and anotherone for airplayer

        if (pGroundCheck.isPlayerGrounded) rb.AddForce(new Vector2(inputs.x * acceleration, 0f));
         else rb.AddForce(new Vector2(inputs.x * airAcceleration, 0f));




        // Since addForce does not limit the speed, we need to limit it.
        if (Mathf.Abs(rb.velocity.x) > maxSpeed) rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * maxSpeed, rb.velocity.y);
           

        //DRAG



        if (GameManager.Instance.thirdPersonCam)
        {
            if (pGroundCheck.isPlayerGrounded) rb.AddForce(new Vector2(-inputs.y * acceleration, 0f));
            else rb.AddForce(new Vector2(-inputs.y * airAcceleration, 0f));

            if ((Mathf.Abs(-inputs.y) < 0.4 && !pJump.isJumping) && (Mathf.Abs(inputs.x) < 0.4 && !pJump.isJumping) || changingDirection) rb.drag = deceleration;
            else rb.drag = 0f;


        }
        else
        {
            if (pGroundCheck.isPlayerGrounded && !GetComponent<PlayerJump>().isHoldingJump)
            {
                //Debug.Log(changingDirection);
                //if the player stops moving we want the drag to be= to the deceleration.

                if ((Mathf.Abs(inputs.x) < 0.4 && !pJump.isJumping) || changingDirection) rb.drag = deceleration;
                else rb.drag = 0f;

            }
        }



    }

}
