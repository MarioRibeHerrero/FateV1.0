using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
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
    [SerializeField] bool isHoldingJump, holdingJumpButton;
    float maxJump;


    //secondJump
    [SerializeField] float secondJumpForce;
    public bool secondJump;
    [SerializeField] GameObject wings;

    //not so local
    public bool isJumping;
    public bool cantHoldJump;

    //CoyoteJump
    [SerializeField] float coyoteTime;
    float coyoteTimer;
    public bool isCoyoteJumping;
    //Jump Buffer
    [SerializeField] float jumpBufferTime;
    [SerializeField] float jumpBufferTimer;
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
        secondJump = true;

    }

    private void Jump_canceled(InputAction.CallbackContext obj)
    {
        holdingJumpButton = false;
        isHoldingJump = false;
    }
    private void Jump_Started(InputAction.CallbackContext obj)
    {
        holdingJumpButton = true;
        if (coyoteTimer > 0)
        {
            isHoldingJump = true;
        }
        


        if(pGroundCheck.isPlayerGrounded || (coyoteTimer > 0)) maxJump = maxJumpValue;

        if(!secondJump) isBufferJumping = true;

        if (isJumping && secondJump)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            rb.velocity = new Vector3(rb.velocity.x, jumpForce * 5, rb.velocity.z);
            secondJump = false;
            StartCoroutine(WingsToTrue());
        }

    }
    private IEnumerator WingsToTrue()
    {
        wings.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        wings.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        maxJump -= Time.deltaTime;
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
            

        }
        if (isBufferJumping && pGroundCheck.isPlayerGrounded && jumpBufferTimer >= 0) 
        {
            if(holdingJumpButton) isHoldingJump = true;
            else
            {
                rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
                rb.velocity = new Vector3(rb.velocity.x, jumpForce * 5, rb.velocity.z);
                isJumping = true;
            }

            maxJump = maxJumpValue;
            isBufferJumping = false;
            
        }
        if(jumpBufferTimer <= 0)
        {
            isBufferJumping = false;

        }




        //Esto no te permite mantener el aslto para saltar todo el rato
        if (rb.velocity.y <= 0 && cantHoldJump)
        {
            cantHoldJump = false;
        }
    }

    private void JumpBuffering()
    {
        if(!isBufferJumping)
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
