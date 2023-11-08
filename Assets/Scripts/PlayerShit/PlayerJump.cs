using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{
    //Components
    PlayerInput playerInput;
    Rigidbody rb;
    PlayerGroundCheck pGroundCheck;

    //local
    [SerializeField] float jumpForce, maxJumpValue;
    [SerializeField] bool isHoldingJump;
    float maxJump, maxJumpB;
    
    //not so local
    public bool isJumping;
    public bool cantHoldJump;

    //CoyoteJump
    [SerializeField] float coyoteTime;
    float coyoteTimer;
    public bool isCoyoteJumping;
    //Jump Buffer
    [SerializeField] float jumpBufferTime;
    float jumpBufferTimer;
    public bool isBufferJumping;
    void Start()
    {
        //Get Components
        playerInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();
        pGroundCheck = GetComponent<PlayerGroundCheck>();

        //Player Input Shit 
        playerInput.actions["Jump"].started += Jump_Started;
        playerInput.actions["Jump"].canceled += Jump_canceled;

        cantHoldJump = true;
    }

    private void Jump_canceled(InputAction.CallbackContext obj)
    {
        isHoldingJump = false;
   
        if(rb.velocity.y !>= 0)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0, 0);
        }
    }
    private void Jump_Started(InputAction.CallbackContext obj)
    {
        
        if( coyoteTimer > 0)
        {
            isHoldingJump = true;

        }
        
        if(pGroundCheck.isPlayerGrounded || (coyoteTimer > 0)) maxJump = maxJumpValue;
        if (jumpBufferTimer > 0) maxJumpB = maxJumpValue;



    }
    // Update is called once per frame
    void Update()
    {
        maxJump -= Time.deltaTime;
        maxJumpB -= Time.deltaTime;
        Jump();
        CoyoteTimer();
        JumpBuffering();
    }

    private void Jump()
    {
        if (isHoldingJump && maxJump >= 0 )
        {
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            rb.velocity = new Vector3(rb.velocity.x, jumpForce * 5, rb.velocity.z);
            isJumping = true;

            isCoyoteJumping = true;

            Debug.Log("Jump1");
        }





        //Esto no te permite mantener el aslto para saltar todo el rato
        if (rb.velocity.y <= 0 && cantHoldJump)
        {
            cantHoldJump = false;
            isHoldingJump = false;
        }
    }

    private void JumpBuffering()
    {
        if(isHoldingJump)
        {
            jumpBufferTimer = jumpBufferTime;
        }
        else
        {
            jumpBufferTimer -= Time.deltaTime;
        }
    }

    private void CoyoteTimer()
    {
        if (pGroundCheck.isPlayerGrounded) coyoteTimer = coyoteTime;
        else coyoteTimer -= Time.deltaTime;
    }
}
