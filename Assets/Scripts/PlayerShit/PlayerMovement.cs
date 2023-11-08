using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //Components
    PlayerInput playerInput;
    Rigidbody rb;
    PlayerGroundCheck pGroundCheck;
    PlayerJump pJump;
    PlayerHook pHook;

    
    [SerializeField] float acceleration, airAcceleration, deceleration, airDeceleration, maxSpeed, fallMultiplier;
    [SerializeField] float gravityScale;
   


    void Start()
    {
        //Get Components
        playerInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();
        pGroundCheck = GetComponent<PlayerGroundCheck>();
        pJump = GetComponent<PlayerJump>();
        pHook = GetComponent<PlayerHook>();
        //PlayerInputShit


    }
    private Vector2 GetInputs()
    {
        Vector2 inputs;
        inputs = playerInput.actions["XMovement"].ReadValue<Vector2>();
        return inputs;
    }



    // Update is called once per frame
    void Update()
    {
        if (!pHook.isHooking)
        {
            GravityScale();
            Movement();
        }

    }

    private void GravityScale()
    {
        Vector3 gravityVector = new Vector3(0, -gravityScale, 0);
        rb.AddForce(gravityVector, ForceMode.Acceleration);
        if (rb.velocity.y <= 0) rb.drag = 0f;
    }
    private void Movement()
    {
        //MOVEMENT

        //we set a movement speed for the grounded player and anotherone for airplayer
        if (pGroundCheck.isPlayerGrounded) rb.AddForce(new Vector2(GetInputs().x * acceleration, 0f));
        else rb.AddForce(new Vector2(GetInputs().x * airAcceleration, 0f));

        // Since addForce does not limit the speed, we need to limit it.
        if (Mathf.Abs(rb.velocity.x) > maxSpeed) rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * maxSpeed, rb.velocity.y);

        //DRAG
        if (pGroundCheck.isPlayerGrounded)
        {
            //if the player stops moving we want the drag to be= to the deceleration.
            if (Mathf.Abs(GetInputs().x) < 0.4 && !pJump.isJumping) rb.drag = deceleration;
            else rb.drag = 0f;
        }
       
    }

}
