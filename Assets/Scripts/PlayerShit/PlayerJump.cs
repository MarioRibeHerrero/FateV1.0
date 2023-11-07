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
    float maxJump;

    //not so local
    public bool isJumping;

    void Start()
    {
        //Get Components
        playerInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();
        pGroundCheck = GetComponent<PlayerGroundCheck>();


        playerInput.actions["Jump"].started += Jump_Started;
        playerInput.actions["Jump"].canceled += Jump_canceled;
    }

    private void Jump_canceled(InputAction.CallbackContext obj)
    {
        
        isHoldingJump = false;
    }
    private void Jump_Started(InputAction.CallbackContext obj)
    {
       
        if (pGroundCheck.isPlayerGrounded)
        {
            Debug.Log("GOLA");
            isHoldingJump = true;
            maxJump = maxJumpValue;
        }



    }
    // Update is called once per frame
    void Update()
    {
        maxJump -= Time.deltaTime;
        if (isHoldingJump && maxJump >= 0)
        {
            
            rb.velocity = new Vector3(rb.velocity.x, jumpForce * 5, rb.velocity.z);
            isJumping = true;
        }
    }


}
