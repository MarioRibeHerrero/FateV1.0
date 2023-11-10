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

    //Movement variables
    [SerializeField] float acceleration, airAcceleration, deceleration, maxSpeed;
    [SerializeField] float gravityScale;

    //public
    public bool hasStopedMidAir;

    void Start()
    {
        //Get Components
        playerInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();
        pGroundCheck = GetComponent<PlayerGroundCheck>();
        pJump = GetComponent<PlayerJump>();
        pHook = GetComponent<PlayerHook>();

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

    void Update()
    {
        //we activame the moving system if you are not ocupied
        if (!pHook.isHooking && GameManager.Instance.canPlayerMove)
        {
            GravityScale();
            Movement();
        }
    }

    private void GravityScale()
    {
        //Apply gravity
        Vector3 gravityVector = new Vector3(0, -gravityScale, 0);
        rb.AddForce(gravityVector, ForceMode.Acceleration);
        //set drag to 0 when falling
        if (rb.velocity.y <= 0) rb.drag = 0f;
    }
    private void Movement()
    {
        //we set a movement aceleration for the grounded player and anotherone for airplayer
        if (pGroundCheck.isPlayerGrounded) rb.AddForce(new Vector2(GetInputsX().x * acceleration, 0f));
        else rb.AddForce(new Vector2(GetInputsX().x * airAcceleration, 0f));

        // Since addForce does not limit the speed, we need to limit it.
        if (Mathf.Abs(rb.velocity.x) > maxSpeed) rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * maxSpeed, rb.velocity.y);

        //DRAG
        if (pGroundCheck.isPlayerGrounded)
        {
            //if the player stops moving we want the drag to be= to the deceleration.
            if (Mathf.Abs(GetInputsX().x) < 0.4 && !pJump.isJumping) rb.drag = deceleration;
            else rb.drag = 0f;
        }

        /*
         * DARLE UNA VUELTA(si saltas parado y te mueves luego no va, si paras mueves paras y mueves no va, si usas hook no va)
         * 
        if (!hasStopedMidAir && Mathf.Abs(GetInputsX().x) <= 0.4 && !pGroundCheck.isPlayerGrounded && !pHook.isHooking)
        {
            hasStopedMidAir = true;
            rb.velocity = new Vector3(0, rb.velocity.y, 0f);
        }
        */
    }

}
